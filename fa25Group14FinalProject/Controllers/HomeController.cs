using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using fa25Group14FinalProject.DAL; // Assuming your DbContext is here
using Microsoft.AspNetCore.Identity;
using fa25Group14FinalProject.Models; // For AppUser

namespace fa25Group14FinalProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        // Constructor to inject the context and UserManager
        public HomeController(AppDbContext appDbContext, UserManager<AppUser> userManager)
        {
            _context = appDbContext;
            _userManager = userManager;
        }

        // GET: /Home/
        public async Task<IActionResult> Index() // Make action async
        {
            // Check if the user is authenticated (logged in)
            if (User.Identity.IsAuthenticated)
            {
                // 1. Get the AppUser object using the logged-in user's ID
                AppUser user = await _userManager.GetUserAsync(User);

                // 2. Pass the First and Last Name properties to the view
                if (user != null)
                {
                    ViewBag.CustomerName = $"{user.FirstName} {user.LastName}".Trim();
                }
            }
            else
            {
                ViewBag.CustomerName = null;
            }

            return View();
        }
    }
}