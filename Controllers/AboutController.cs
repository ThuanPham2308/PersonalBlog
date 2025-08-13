using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data;

namespace PersonalBlog.Controllers
{
    public class AboutController : Controller
    {
        private readonly PersonalBlogContext _context;

        public AboutController(PersonalBlogContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var about = _context.Abouts.FirstOrDefault();
            ViewBag.Skills = _context.Skills.ToList();
            ViewBag.Educations = _context.Educations.ToList();
            ViewBag.Experiences = _context.Experiences.ToList();
            return View(about);
        }
    }
}
