using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Data;
using PersonalBlog.Services; 

namespace PersonalBlog.Controllers
{
    public class AdminController : Controller
    {
        private readonly PersonalBlogContext _context;
        private readonly AuthService _authService;

        public AdminController(PersonalBlogContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public IActionResult Index()
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");

            var about = _context.Abouts.FirstOrDefault();
            return View(about);
        }
        public IActionResult About()
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");

            var about = _context.Abouts.FirstOrDefault();
            ViewBag.Skills = _context.Skills.ToList();
            ViewBag.Educations = _context.Educations.ToList();
            ViewBag.Experiences = _context.Experiences.ToList();
            return View(about);
        }
        public IActionResult Portfolio()
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");

            var portfolios = _context.Portfolios.ToList();
            return View(portfolios);
        }

        public IActionResult Blogs()
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");

            var blogs = _context.Blogs.ToList();
            return View(blogs);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "123")
            {
                HttpContext.Session.SetString("IsAdmin", "true");
                return RedirectToAction("Index", "Admin");
            }

            ViewBag.Error = "Sai tài khoản hoặc mật khẩu!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IsAdmin");
            return RedirectToAction("Login", "Admin");
        }
    }
}
