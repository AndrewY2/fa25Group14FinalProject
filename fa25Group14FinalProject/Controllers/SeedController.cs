using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// Update this using statement to include your project name
using fa25Group14FinalProject.Models;
using fa25Group14FinalProject.DAL;
using System;

// Upddate this namespace to match your project name
namespace fa25Group14FinalProject.Controllers
{
    public class SeedController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedController(AppDbContext db, UserManager<AppUser> um, RoleManager<IdentityRole> rm)
        {
            _context = db;
            _userManager = um;
            _roleManager = rm;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SeedRoles()
        {
            try
            {
                //call the method to seed the roles
                await Seeding.SeedRoles.AddAllRoles(_roleManager);
            }
            catch (Exception ex)
            {
                //add the error messages to a list of strings
                List<String> errorList = new List<String>();

                //Add the outer message
                errorList.Add(ex.Message);

                //Add the message from the inner exception
                if (ex.InnerException != null)
                {
                    errorList.Add(ex.InnerException.Message);

                    //Add additional inner exception messages, if there are any
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }
                }

                return View("Error", errorList);
            }

            //this is the happy path - seeding worked!
            return View("Confirm");
        }

        // Seed genres (wrap synchronous seeder in Task.Run so it can be awaited)
        public async Task<IActionResult> SeedGenres()
        {
            try
            {
                await Task.Run(() => Seeding.SeedGenres.SeedAllGenres(_context));
            }
            catch (Exception ex)
            {
                List<String> errorList = new List<String>();
                errorList.Add(ex.Message);

                if (ex.InnerException != null)
                {
                    errorList.Add(ex.InnerException.Message);
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }
                }

                return View("Error", errorList);
            }

            return View("Confirm");
        }

        public async Task<IActionResult> SeedBooks()
        {
            try
            {
                await Task.Run(() => Seeding.SeedBooks.SeedAllBooks(_context));
            }
            catch (Exception ex)
            {
                List<String> errorList = new List<String>();
                errorList.Add(ex.Message);

                if (ex.InnerException != null)
                {
                    errorList.Add(ex.InnerException.Message);
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }
                }

                return View("Error", errorList);
            }

            return View("Confirm");
        }

        // Seed cards
        public async Task<IActionResult> SeedCards()
        {
            try
            {
                await Task.Run(() => Seeding.SeedCards.SeedAllCards(_context));
            }
            catch (Exception ex)
            {
                List<String> errorList = new List<String>();
                errorList.Add(ex.Message);

                if (ex.InnerException != null)
                {
                    errorList.Add(ex.InnerException.Message);
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }
                }

                return View("Error", errorList);
            }

            return View("Confirm");
        }

        // Seed orders
        public async Task<IActionResult> SeedOrders()
        {
            try
            {
                await Task.Run(() => Seeding.SeedOrders.SeedAllOrders(_context));
            }
            catch (Exception ex)
            {
                List<String> errorList = new List<String>();
                errorList.Add(ex.Message);

                if (ex.InnerException != null)
                {
                    errorList.Add(ex.InnerException.Message);
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }
                }

                return View("Error", errorList);
            }

            return View("Confirm");
        }

        // Seed reviews
        public async Task<IActionResult> SeedReviews()
        {
            try
            {
                await Task.Run(() => Seeding.SeedReviews.SeedAllReviews(_context));
            }
            catch (Exception ex)
            {
                List<String> errorList = new List<String>();
                errorList.Add(ex.Message);

                if (ex.InnerException != null)
                {
                    errorList.Add(ex.InnerException.Message);
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }
                }

                return View("Error", errorList);
            }

            return View("Confirm");
        }

        public async Task<IActionResult> SeedPeople()
        {
            try
            {
                //call the method to seed the users
                await Seeding.SeedUsers.SeedAllUsers(_userManager, _context);
            }
            catch (Exception ex)
            {
                //add the error messages to a list of strings
                List<String> errorList = new List<String>();

                //Add the outer message
                errorList.Add(ex.Message);

                if (ex.InnerException != null)
                {
                    //Add the message from the inner exception
                    errorList.Add(ex.InnerException.Message);

                    //Add additional inner exception messages, if there are any
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }

                }


                return View("Error", errorList);
            }

            //this is the happy path - seeding worked!
            return View("Confirm");
        }
    }
}
