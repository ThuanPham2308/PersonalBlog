using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Data;
using Microsoft.AspNetCore.Http; 

namespace PersonalBlog.Controllers
{
    public class AdminController : Controller
    {
        private readonly PersonalBlogContext _context;

        public AdminController(PersonalBlogContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var isAdmin = HttpContext.Session.GetString("IsAdmin");
            if (isAdmin != "true")
            {
                return RedirectToAction("Login");
            }

            return View();
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
