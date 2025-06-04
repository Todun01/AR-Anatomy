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
        private readonly UserManager<ApplicationUser> _userManager;
        
        public HomeController(ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _context = context;
            _userManager = userManager;
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
        [HttpPost]
        public async Task<IActionResult> CreateFeedback(FeedbackDto feedbackDto)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;
            if (userId == null)
            {
                _logger.LogInformation("no user id");
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => $"{x.Key}: {string.Join(", ", x.Value.Errors.Select(e => e.ErrorMessage))}");

                _logger.LogError("🚨 VALIDATION FAILED: {Errors}", string.Join(" | ", errors));
                return RedirectToAction("Feedback", "Home");
            }

            Feedback feedback = new Feedback()
            {
                UserId = userId,
                OrganModelId = feedbackDto.OrganModelId,
                Comment = feedbackDto.Comment,
                Rating = feedbackDto.Rating,
            };
            _context.Feedback.Add(feedback);
            _context.SaveChanges();
            _logger.LogInformation("success");
            return RedirectToAction("Feedback", "Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
