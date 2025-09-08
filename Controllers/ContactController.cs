using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Data;
using PersonalBlog.Models;
using System.Net.Mail;

namespace PersonalBlog.Controllers
{
    public class ContactController : Controller
    {
        private readonly PersonalBlogContext _context;
        private readonly IConfiguration _configuration;

        public ContactController(PersonalBlogContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var about = _context.Abouts.FirstOrDefault();
            return View(about);
        }
        [HttpPost]
        public IActionResult Send(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new System.Net.NetworkCredential(_configuration["KeyApp:Email"], _configuration["KeyApp:Password"]);
                    smtp.EnableSsl = true;
                    var mail = new MailMessage();
                    mail.From = new MailAddress(model.Email);
                    mail.To.Add(_configuration["KeyApp:Email"]);
                    mail.Subject = model.Subject;
                    mail.Body = $"Name: {model.Name}\nEmail: {model.Email}\nMessage: {model.Message}";
                    smtp.Send(mail);
                }
                ViewBag.Message = "Gửi thành công!";
            }
            return RedirectToAction("Index", "Contact");
        }
    }
}
