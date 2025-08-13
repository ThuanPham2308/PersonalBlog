using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Data;
using System.Linq;

namespace PersonalBlog.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly PersonalBlogContext _context;

        public PortfolioController(PersonalBlogContext context)
        {
            _context = context;
        }

        public IActionResult Index(string category)
        {
            ViewBag.Categories = _context.Portfolios
                                           .Select(p => p.Category)
                                           .Distinct()
                                           .ToList();

            var portfolios = _context.Portfolios.AsQueryable();
            if (!string.IsNullOrEmpty(category) && category != "all")
            {
                portfolios = portfolios.Where(p => p.Category == category);
            }

            ViewBag.SelectedCategory = category ?? "all";
            return View(portfolios.ToList());
        }
    }
}
