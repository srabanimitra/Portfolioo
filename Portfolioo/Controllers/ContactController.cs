
using Portfolioo.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Portfolioo.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View(new ContactMessage());
        }

        [HttpPost]
        public ActionResult Index(ContactMessage model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve existing list from session
                var messages = Session["Messages"] as List<ContactMessage> ?? new List<ContactMessage>();

                // Add new message
                model.DateSent = DateTime.Now;
                messages.Add(model);

                // Save back to session
                Session["Messages"] = messages;

                ViewBag.Success = "Your message has been sent successfully!";
                ModelState.Clear();
                return View(new ContactMessage());
            }
            return View(model);
        }

        // Admin view to list all messages
        public ActionResult Admin()
        {
            var messages = Session["Messages"] as List<ContactMessage> ?? new List<ContactMessage>();
            return View(messages);
        }
    }
}
