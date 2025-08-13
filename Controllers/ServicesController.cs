using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Data;

namespace PersonalBlog.Controllers
{
    public class ServicesController : Controller
    {
        private readonly PersonalBlogContext _context;

        public ServicesController(PersonalBlogContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Services = _context.Services.ToList();
            return View();
        }
    }
}
