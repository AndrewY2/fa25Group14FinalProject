using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using fa25Group14FinalProject.Utilities; // Assuming you have an Email/Utilities service
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic; // Added for List

namespace fa25Group14FinalProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public AccountController(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signIn)
        {
            _context = appDbContext;
            _userManager = userManager;
            _signInManager = signIn;
            // Note: Password validation will be handled by the Identity configuration (Startup.cs)
        }

        // Helper: Get the current logged-in user ID
        private String GetUserID()
        {
            return _userManager.GetUserId(User);
        }

        // --- ACCOUNT CREATION (REGISTER) ---

        // GET: /Account/Register (Customer Functionality: Create Account)
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }


        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid == false)
            {
                return View(rvm);
            }

            // Map RegisterViewModel to AppUser domain model and include all required fields
            AppUser newUser = new AppUser
            {
                UserName = rvm.Email,
                Email = rvm.Email,
                PhoneNumber = rvm.PhoneNumber,
                FirstName = rvm.FirstName,
                LastName = rvm.LastName,
                //commented out for milestone 6
                Address = rvm.Address,
                City = rvm.City,
                State = rvm.State,
                ZipCode = rvm.ZipCode,
                IsActive = true // Accounts are active by default
            };

            AddUserModel aum = new AddUserModel()
            {
                User = newUser,
                Password = rvm.Password,
                RoleName = "Customer" // All new sign-ups are customers
            };

            IdentityResult result = await Utilities.AddUser.AddUserWithRoleAsync(aum, _userManager, _context);

            if (result.Succeeded)
            {
                // Send confirmation email (Required: account created) – include Team 14 in subject
                string subject = "Team 14: Account Confirmation";
                string body =
                    $"Hi {newUser.FirstName},\n\n" +
                    "Welcome to Bevo's Books! Your customer account has been created successfully.\n\n" +
                    "You can now log in, browse books, and start building your library.\n\n" +
                    "Thanks for choosing us!\n" +
                    "Team 14 – Bevo's Books";

                await EmailUtils.SendEmailAsync(newUser.Email, subject, body);

                if (!User.Identity.IsAuthenticated)
                {
                    // Normal customer self-registration
                    await _signInManager.PasswordSignInAsync(rvm.Email, rvm.Password, false, lockoutOnFailure: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // An employee/admin created this customer while already logged in.
                    // Do NOT sign in as the new customer – keep the current user.
                    TempData["SuccessMessage"] = $"Customer account for {newUser.Email} created successfully.";
                    return RedirectToAction("ManageCustomers", "Employees");
                }
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(rvm);
            }
        }


        // --- LOGIN/LOGOUT ---

        // GET: /Account/Login
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "Access Denied" });
            }
            _signInManager.SignOutAsync();
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid == false)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(lvm);
            }

            // 1. Check if the account is disabled (Required)
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == lvm.Email);

            if (user != null && user.IsActive == false)
            {
                ModelState.AddModelError("", "Your account has been disabled. Please contact support.");
                return View(lvm);
            }

            // 2. Attempt to sign the user in
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, lvm.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                string returnUrl = Request.Query["returnUrl"].ToString();

                if (string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect("/");
                }

                return Redirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(lvm);
            }
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // --- ACCOUNT MANAGEMENT (CUSTOMER) ---

        // GET: Account/Index (View Account Information & Cards)
        //added for milestone 6
        [Authorize]
        public async Task<IActionResult> Index()
        {
            String id = GetUserID();
            // Fetch user data including cards
            AppUser user = await _context.Users
                .Include(u => u.Cards)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null) return NotFound();

            AccountIndexViewModel viewModel = new AccountIndexViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                City = user.City,
                State = user.State,
                ZipCode = user.ZipCode,
                Cards = user.Cards // Pass the related card collection
            };
            return View(viewModel);
        }

        // GET: Account/Modify (Modify allowed fields)
        public async Task<IActionResult> Modify()
        {
            String id = GetUserID();
            AppUser user = await _userManager.FindByIdAsync(id);

            return View(user);
        }

        // POST: Account/Modify
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modify([Bind("Id,FirstName,LastName,Address,City,State,ZipCode,PhoneNumber")] AppUser updatedUser)
        {
            ModelState.Remove("Email");
            ModelState.Remove("UserName");

            if (ModelState.IsValid == false)
            {
                // Rename variable to avoid CS0136 shadowing and handle possible null for CS8600
                var userToModifyView = await _userManager.FindByIdAsync(updatedUser.Id);
                if (userToModifyView == null) return NotFound();
                return View(userToModifyView);
            }

            // Use a different variable name to avoid shadowing
            var userToModify = _context.Users.FirstOrDefault(u => u.Id == updatedUser.Id);

            if (userToModify == null) return NotFound();

            // Update only the allowed fields [cite: 66]
            userToModify.FirstName = updatedUser.FirstName;
            userToModify.LastName = updatedUser.LastName;
            userToModify.Address = updatedUser.Address;
            userToModify.PhoneNumber = updatedUser.PhoneNumber;
            userToModify.City = updatedUser.City;
            userToModify.State = updatedUser.State;
            userToModify.ZipCode = updatedUser.ZipCode;

            _context.Update(userToModify);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Account successfully updated.";
            return RedirectToAction(nameof(Index));
        }


        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel cpvm)
        {
            if (ModelState.IsValid == false)
            {
                return View(cpvm);
            }

            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);

            // Requires verification by entering in the old password (handled by ChangePasswordAsync) [cite: 71]
            var result = await _userManager.ChangePasswordAsync(userLoggedIn, cpvm.OldPassword, cpvm.NewPassword);

            if (result.Succeeded)
            {
                // Send email notification for password change (Required)
                string subject = "Team 14: Password Changed";
                string body =
                    $"Hi {userLoggedIn.FirstName},\n\n" +
                    "This is a confirmation that your password for Bevo's Books has just been changed.\n\n" +
                    "If you did not make this change, please contact support immediately.\n\n" +
                    "Team 14 – Bevo's Books";

                await EmailUtils.SendEmailAsync(userLoggedIn.Email, subject, body);

                await _signInManager.SignInAsync(userLoggedIn, isPersistent: false);

                TempData["SuccessMessage"] = "Password successfully changed.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(cpvm);
            }
        }


        // --- CREDIT CARD MANAGEMENT ---

        // GET: Account/AddCard (Accessed from Account/Index)
        public async Task<IActionResult> AddCard()
        {
            String id = GetUserID();
            AppUser user = await _context.Users.Include(u => u.Cards).FirstOrDefaultAsync(u => u.Id == id);

            // Check card limit (up to 3 maximum credit cards per customer) 
            if (user.Cards.Count >= 3)
            {
                TempData["ErrorMessage"] = "You have reached the maximum limit of 3 credit cards.";
                return RedirectToAction(nameof(Index));
            }

            return View(new Card());
        }
        // POST: Account/AddCard
        // POST: Account/AddCard
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCard([Bind("CardNumber,CardType")] Card newCard)
        {
            // 1. Sanitize CardNumber and remove its previous ModelState error (if necessary)
            if (!string.IsNullOrWhiteSpace(newCard.CardNumber))
            {
                newCard.CardNumber = new string(newCard.CardNumber.Where(char.IsDigit).ToArray());
                ModelState.Remove(nameof(newCard.CardNumber));
            }

            // 2. Set the foreign key
            newCard.CustomerID = GetUserID();

            // 3. CRITICAL FIX: Remove the ModelState error for CustomerID
            // The Model Binder marked this field invalid because it wasn't in the form, 
            // even though we are setting it manually.
            ModelState.Remove(nameof(newCard.CustomerID));

            if (ModelState.IsValid)
            {
                // Re-check count inside POST to prevent concurrent adds exceeding the limit
                int cardCount = _context.Cards.Count(c => c.CustomerID == newCard.CustomerID);
                if (cardCount >= 3)
                {
                    ModelState.AddModelError("", "Cannot add card: Maximum limit of 3 reached.");
                    return View(newCard);
                }

                _context.Cards.Add(newCard);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"New {newCard.CardType} card added successfully.";
                return RedirectToAction(nameof(Index));
            }

            // This return View is what causes the refresh if the model is invalid
            return View(newCard);
        }
        // POST: Account/RemoveCard/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveCard(int id)
        {
            Card cardToRemove = await _context.Cards
                .FirstOrDefaultAsync(c => c.CardID == id && c.CustomerID == GetUserID());

            if (cardToRemove == null) return NotFound();

            // Note: If the card is in use on a finalized order, deleting the card record is fine,
            // as the Order table retains the CardID (FK) but not the Navigational Property.

            _context.Cards.Remove(cardToRemove);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Credit card removed successfully.";
            return RedirectToAction(nameof(Index));
        }


        public IActionResult AccessDenied()
        {
            return View("Error", new string[] { "You are not authorized for this resource" });
        }
    }
}