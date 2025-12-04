using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using fa25Group14FinalProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace fa25Group14FinalProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleAdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleAdminController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: /RoleAdmin/ (Displays all roles)
        public async Task<ActionResult> Index()
        {
            List<IdentityRole> allRoles = await _roleManager.Roles.ToListAsync();
            List<AppUser> allUsers = await _userManager.Users.ToListAsync();

            List<RoleEditModel> roles = new List<RoleEditModel>();

            foreach (IdentityRole role in allRoles)
            {
                List<AppUser> RoleMembers = new List<AppUser>();
                List<AppUser> RoleNonMembers = new List<AppUser>();

                foreach (AppUser user in allUsers)
                {
                    if (await _userManager.IsInRoleAsync(user, role.Name) == true)
                    {
                        RoleMembers.Add(user);
                    }
                    else
                    {
                        RoleNonMembers.Add(user);
                    }
                }

                RoleEditModel rem = new RoleEditModel();
                rem.Role = role;
                rem.RoleMembers = RoleMembers;
                rem.RoleNonMembers = RoleNonMembers;

                roles.Add(rem);
            }

            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(name);
        }

        public async Task<ActionResult> Edit(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            List<AppUser> allUsers = await _userManager.Users.ToListAsync();

            List<AppUser> RoleMembers = new List<AppUser>();
            List<AppUser> RoleNonMembers = new List<AppUser>();

            foreach (AppUser user in allUsers)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name) == true)
                {
                    RoleMembers.Add(user);
                }
                else
                {
                    RoleNonMembers.Add(user);
                }
            }

            RoleEditModel rem = new RoleEditModel();
            rem.Role = role;
            rem.RoleMembers = RoleMembers;
            rem.RoleNonMembers = RoleNonMembers;

            return View(rem);
        }

        // POST: /RoleAdmin/Edit (Handles Role Assignment, Hire, and Fire)
        [HttpPost]
        public async Task<ActionResult> Edit(RoleModificationModel rmm)
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                // Logic to add users to the role (Hiring/Rehiring)
                if (rmm.IdsToAdd != null)
                {
                    foreach (string userId in rmm.IdsToAdd.Where(id => !string.IsNullOrEmpty(id)))
                    {
                        AppUser user = await _userManager.FindByIdAsync(userId);
                        if (user == null) return View("Error", new string[] { $"User ID {userId} not found." });

                        // Attempt to add the user to the role
                        result = await _userManager.AddToRoleAsync(user, rmm.RoleName);
                        if (result.Succeeded == false) return View("Error", result.Errors);

                        // HIRE/REHIRE LOGIC: If added to Employee/Admin role, ensure they are Active.
                        // This covers both initial hiring and rehiring a former employee.
                        if ((rmm.RoleName == "Employee" || rmm.RoleName == "Admin") && user.IsActive == false)
                        {
                            user.IsActive = true;
                            await _userManager.UpdateAsync(user);
                        }
                    }
                }

                // Logic to remove users from the role (Firing/Demoting)
                if (rmm.IdsToDelete != null)
                {
                    foreach (string userId in rmm.IdsToDelete.Where(id => !string.IsNullOrEmpty(id)))
                    {
                        AppUser user = await _userManager.FindByIdAsync(userId);
                        if (user == null) return View("Error", new string[] { $"User ID {userId} not found." });

                        // FIRE LOGIC CHECK: Determine if the user should be disabled (fired) after removal
                        if (rmm.RoleName == "Employee" || rmm.RoleName == "Admin")
                        {
                            // Get the user's current roles before removing the target role
                            var currentRoles = await _userManager.GetRolesAsync(user);

                            // If the user's *only* remaining administrative role is the one being removed, disable them.
                            // The Contains check ensures we only fire if this was their last Admin/Employee role.
                            if (currentRoles.Contains(rmm.RoleName) && currentRoles.Count(r => r == "Employee" || r == "Admin") == 1)
                            {
                                user.IsActive = false; // Former employees should be blocked from logging in
                                await _userManager.UpdateAsync(user);
                            }
                        }

                        // Attempt to remove the user from the role
                        result = await _userManager.RemoveFromRoleAsync(user, rmm.RoleName);

                        if (result.Succeeded == false) return View("Error", result.Errors);
                    }
                }

                // Happy path
                return RedirectToAction("Index");
            }

            // Sad path
            return View("Error", new string[] { "Role Not Found" });
        }
    }
}