using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Data;

namespace PersonalBlog.Controllers
{
    public class ContactController : Controller
    {
        private readonly PersonalBlogContext _context;

        public ContactController(PersonalBlogContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var about = _context.Abouts.FirstOrDefault();
            return View(about);
        }
    }
}
