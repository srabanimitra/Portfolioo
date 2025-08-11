using Portfolioo.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Portfolioo.Controllers
{
    public class ProjectsController : Controller
    {
        public ActionResult Index()
        {
            var projects = new List<Project>
            {
                new Project { Title = "Portfolio Website", Description = "A personal portfolio site", ImagePath = "/images/portfolio.jpg" },
                new Project { Title = "E-Commerce App", Description = "Online shop platform", ImagePath = "/images/shop.jpg" }
            };

            return View(projects);
        }
    }
}
