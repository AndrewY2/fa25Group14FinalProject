using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using fa25Group14FinalProject.DAL;
using Microsoft.AspNetCore.Identity;
using fa25Group14FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace fa25Group14FinalProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(AppDbContext appDbContext, UserManager<AppUser> userManager)
        {
            _context = appDbContext;
            _userManager = userManager;
        }

        // GET: /Home/
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.GetUserAsync(User);

                if (user != null)
                {
                    ViewBag.CustomerName = $"{user.FirstName} {user.LastName}".Trim();
                }
            }
            else
            {
                ViewBag.CustomerName = null;
            }

            // 🔹 Only customers see advertised coupons on the home page
            if (User.IsInRole("Customer"))
            {
                var activeCoupons = _context.Coupons
                                           .Where(c => c.Status == true)
                                           .ToList();
                ViewBag.ActiveCoupons = activeCoupons;
            }

            return View();
        }
    }
}
