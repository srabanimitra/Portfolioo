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
            new BlogPost { Id = 1, Title = "First Post", Content = "This is my first blog post!" +"\n"
                +" Here i will share my experience about coding journey,travels,new events.", Date = System.DateTime.Now },
            new BlogPost { Id = 2, Title = "The Benefits of Practicing Mindfulness", Content = "1. Reduces Stress and Anxiety\r\nBy focusing on the present, mindfulness interrupts the cycle of worry about the past or the future. Studies have shown that mindfulness-based stress reduction (MBSR) programs significantly lower cortisol (the stress hormone) and help people feel calmer.\r\n\r\n2. Improves Focus and Concentration\r\nWhen your mind isn’t constantly pulled in ten directions, you can give your full attention to what matters right now. Over time, mindfulness strengthens your ability to stay focused—even during challenging or monotonous tasks.\r\n\r\n3. Boosts Emotional Regulation\r\nMindfulness helps you notice emotions as they arise, creating space to choose how to respond rather than reacting impulsively. This leads to healthier relationships and fewer “I wish I hadn’t said that” moments.\r\n\r\n4. Enhances Physical Well-being\r\nMindfulness isn’t just good for your mind—it’s good for your body, too. Research links mindfulness practices to improved immune function, lower blood pressure, and better sleep quality.\r\n\r\n5. Increases Self-Awareness\r\nBy observing your thoughts and feelings without judgment, you become more attuned to your patterns and triggers. This self-awareness is the foundation for personal growth and positive change.", Date = System.DateTime.Now }
        };

        public ActionResult Index()
        {
            return View(_posts);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index"); // or some NotFound page

            var post = _posts.FirstOrDefault(p => p.Id == id.Value);
            if (post == null)
                return HttpNotFound();

            return View(post);
        }


        [HttpPost]
        public ActionResult AddComment(int id, string comment)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post != null && !string.IsNullOrWhiteSpace(comment))
            {
                post.Comments.Add(new Comment { Text = comment });
                Session[$"comments_{id}"] = post.Comments;
            }
            return RedirectToAction("Details", new { id });
        }


        [HttpPost]
      
        public ActionResult AddReply(int id, int commentIndex, string reply)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post != null && commentIndex >= 0 && commentIndex < post.Comments.Count && !string.IsNullOrWhiteSpace(reply))
            {
                post.Comments[commentIndex].Replies.Add(reply);
                Session[$"comments_{id}"] = post.Comments;
            }
            return RedirectToAction("Details", new { id });
        }

    }
}
