using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Data;

namespace PersonalBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly PersonalBlogContext _context;

        public BlogController(PersonalBlogContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Blogs = _context.Blogs.ToList();    
            return View();
        }
        public IActionResult Details(int id)
        {
            var blog = _context.Blogs.FirstOrDefault(b => b.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }
    }
}
