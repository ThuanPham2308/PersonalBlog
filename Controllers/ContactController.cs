using Microsoft.AspNetCore.Mvc;

namespace PersonalBlog.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
