using Microsoft.AspNetCore.Mvc;

namespace PersonalBlog.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
