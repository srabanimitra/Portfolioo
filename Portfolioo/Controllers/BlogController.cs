using Portfolioo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Portfolioo.Controllers
{
    public class BlogController : Controller
    {
        private static List<BlogPost> _posts = new List<BlogPost>
        {
            new BlogPost { Id = 1, Title = "First Post", Content = "This is my first blog post!", Date = System.DateTime.Now },
            new BlogPost { Id = 2, Title = "ASP.NET MVC Tips", Content = "Learn MVC without a database!", Date = System.DateTime.Now }
        };

        public ActionResult Index()
        {
            return View(_posts);
        }

        public ActionResult Details(int id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            return View(post);
        }

        [HttpPost]
        public ActionResult AddComment(int id, string comment)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post != null && !string.IsNullOrWhiteSpace(comment))
            {
                post.Comments.Add(comment);
                Session[$"comments_{id}"] = post.Comments;
            }
            return RedirectToAction("Details", new { id });
        }
    }
}
