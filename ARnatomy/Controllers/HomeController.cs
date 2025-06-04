using System.Diagnostics;
using System.Net.NetworkInformation;
using ARnatomy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ARnatomy.Data;

namespace ARnatomy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _logger = logger;
            _signInManager = signInManager;
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SkeletalSystem() { 
            if (_signInManager.IsSignedIn(User)){
                return View();
            }
            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            
        }
        public IActionResult MuscularSystem()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
        }
        public IActionResult DigestiveSystem() // digestive system
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" }); 
            }
        }
        public IActionResult EndocrineSystem() { // endocrine system
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
        }
        public IActionResult NervousSystem() // nervous system
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
        }
        public IActionResult Feedback()
        {

            if (_signInManager.IsSignedIn(User))
            {
                var organModels = _context.OrganModels.ToList();
                return View(organModels);
            }
            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
