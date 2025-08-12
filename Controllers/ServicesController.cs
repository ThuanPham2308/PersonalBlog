using Microsoft.AspNetCore.Mvc;

namespace PersonalBlog.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
