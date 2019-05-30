using ProiectCloud.Web.Business;
using ProiectCloud.Web.Entities;
using ProiectCloud.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tema4Cloud.Model;

namespace ProiectCloud.Web.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            ViewBag.Message = "Your Events page.";

            IEnumerable<EventDTO> events = new EventManager().GetEvents();


            if (events == null)
            {
                events = Enumerable.Empty<EventDTO>();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(events);

            //return View();
        }


        public ActionResult Details(int id)
        {
            ViewBag.Message = "Your Events page.";

            Event ev = new EventManager().GetEventById(id);


            if (ev == null)
            {
                ev = new Event();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(ev);

            //return View();
        }

        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            ViewBag.Message = "Create Event";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventViewModel model)
        {
            ViewBag.Message = "Your Event";

            if (ModelState.IsValid)
            {
                if (new EventManager().AddEvent(model.GetAsEvent()))
                    return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult AddComment(CommentViewModel com)
        {
            
           com.Author = HttpContext.User.Identity.Name;

           return RedirectToAction("Details/"+com.EventId);
        }
        
    }
}