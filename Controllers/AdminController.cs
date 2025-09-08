using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Data;
using PersonalBlog.Services; 

namespace PersonalBlog.Controllers
{
    public class AdminController : Controller
    {
        private readonly PersonalBlogContext _context;
        private readonly AuthService _authService;

        public AdminController(PersonalBlogContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public IActionResult Index()
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");

            var about = _context.Abouts.FirstOrDefault();
            return View(about);
        }
        public IActionResult About()
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");

            var about = _context.Abouts.FirstOrDefault();
            ViewBag.Skills = _context.Skills.ToList();
            ViewBag.Educations = _context.Educations.ToList();
            ViewBag.Experiences = _context.Experiences.ToList();
            return View(about);
        }
        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");

            var existingAbout = _context.Abouts.FirstOrDefault();
            if (existingAbout != null)
            {
                existingAbout.FullName = about.FullName;
                existingAbout.Job = about.Job;
                existingAbout.Bio = about.Bio;
                existingAbout.Birthday = about.Birthday;
                existingAbout.Age = about.Age;
                existingAbout.Degree = about.Degree;
                existingAbout.Email = about.Email;
                existingAbout.Freelance = about.Freelance;
                existingAbout.City = about.City;
                existingAbout.Phone = about.Phone;
                existingAbout.Github = about.Github;
                existingAbout.Facebook = about.Facebook;
                existingAbout.Instagram = about.Instagram;

                _context.SaveChanges();
            }

            return RedirectToAction("About");
        }

        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return RedirectToAction("About");
        }
        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            var existingSkill = _context.Skills.Find(skill.Id);
            if (existingSkill != null)
            {
                existingSkill.SkillName = skill.SkillName;
                existingSkill.Proficiency = skill.Proficiency;
                _context.SaveChanges();
            }
            return RedirectToAction("About");
        }

        public IActionResult DeleteSkill(int id)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            var skill = _context.Skills.Find(id);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
                _context.SaveChanges();
            }
            return RedirectToAction("About");
        }

        [HttpPost]
        public IActionResult CreateEducation(Education education)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            _context.Educations.Add(education);
            _context.SaveChanges();
            return RedirectToAction("About");
        }
        [HttpPost]
        public IActionResult UpdateEducation(Education education)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            var existingEducation = _context.Educations.Find(education.Id);
            if (existingEducation != null)
            {
                existingEducation.Title = education.Title;
                existingEducation.Description = education.Description;
                existingEducation.StartYear = education.StartYear;
                existingEducation.EndYear = education.EndYear;
                _context.SaveChanges();
            }
            return RedirectToAction("About");
        }
        public IActionResult DeleteEducation(int id)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            var education = _context.Educations.Find(id);
            if (education != null)
            {
                _context.Educations.Remove(education);
                _context.SaveChanges();
            }
            return RedirectToAction("About");
        }
        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            _context.Experiences.Add(experience);
            _context.SaveChanges();
            return RedirectToAction("About");
        }
        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            var existingExperience = _context.Experiences.Find(experience.Id);
            if (existingExperience != null)
            {
                existingExperience.Title = experience.Title;
                existingExperience.StartYear = experience.StartYear;
                existingExperience.EndYear = experience.EndYear;
                existingExperience.Description = experience.Description;
                _context.SaveChanges();
            }
            return RedirectToAction("About");
        }
        public IActionResult DeleteExperience(int id)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            var experience = _context.Experiences.Find(id);
            if (experience != null)
            {
                _context.Experiences.Remove(experience);
                _context.SaveChanges();
            }
            return RedirectToAction("About");
        }
        public IActionResult Service()
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            var services = _context.Services.ToList();
            return View(services);
        }
        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction("Service");
        }
        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            var existingService = _context.Services.Find(service.Id);
            if (existingService != null)
            {
                existingService.ServiceName = service.ServiceName;
                existingService.Description = service.Description;
                existingService.Icon = service.Icon;
                _context.SaveChanges();
            }
            return RedirectToAction("Service");
        }
        public IActionResult DeleteService(int id)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            var service = _context.Services.Find(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
            return RedirectToAction("Service");
        }
        public IActionResult Portfolio()
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");

            var portfolios = _context.Portfolios.ToList();
            return View(portfolios);
        }
        [HttpPost]
        public IActionResult CreatePortfolio(Portfolio portfolio)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();
            return RedirectToAction("Portfolio");
        }
        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            var existingPortfolio = _context.Portfolios.Find(portfolio.Id);
            if (existingPortfolio != null)
            {
                existingPortfolio.Title = portfolio.Title;
                existingPortfolio.Description = portfolio.Description;
                existingPortfolio.Image = portfolio.Image;
                existingPortfolio.Link = portfolio.Link;
                existingPortfolio.Category = portfolio.Category;
                _context.SaveChanges();
            }
            return RedirectToAction("Portfolio");
        }
        public IActionResult DeletePortfolio(int id)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            var portfolio = _context.Portfolios.Find(id);
            if (portfolio != null)
            {
                _context.Portfolios.Remove(portfolio);
                _context.SaveChanges();
            }
            return RedirectToAction("Portfolio");
        }

        public IActionResult Blog()
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");

            var blogs = _context.Blogs.ToList();
            return View(blogs);
        }
        [HttpPost]
        public IActionResult CreateBlog(Blog blog)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            blog.PublishDate = DateOnly.FromDateTime(DateTime.Now);
            _context.Blogs.Add(blog);
            _context.SaveChanges();
            return RedirectToAction("Blog");
        }
        [HttpPost]
        public IActionResult UpdateBlog(Blog blog)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            var existingBlog = _context.Blogs.Find(blog.Id);
            if (existingBlog != null)
            {
                existingBlog.Title = blog.Title;
                existingBlog.Tag = blog.Tag;
                existingBlog.Content = blog.Content;
                existingBlog.Summary = blog.Summary;
                existingBlog.PublishDate = blog.PublishDate;
                _context.SaveChanges();
            }
            return RedirectToAction("Blog");
        }
        public IActionResult DeleteBlog(int id)
        {
            if (!_authService.IsAdminLoggedIn())
                return RedirectToAction("Login");
            var blog = _context.Blogs.Find(id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                _context.SaveChanges();
            }
            return RedirectToAction("Blog");
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
