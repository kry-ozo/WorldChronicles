using KronikiPodwalaV2.DataObjects;
using KronikiPodwalaV2.Models;
using KronikiPodwalaV2.Repo.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace KronikiPodwalaV2.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize]
    public class EventsController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly UserManager<AppUser> _userManager;
    

        public EventsController(IUnitOfWork db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            
        }
        public IActionResult Index()
        {
            List<EventModel> eventModels = (List<EventModel>)_db.Event.GetAll();
            return View(eventModels);
        }
        public IActionResult ShowEvent(int id)
        {
            EventModel m = _db.Event.Get(id);
            List<Comment> comms = (List<Comment>)_db.Comment.GetAll();
            List<Comment> foundComments = new List<Comment>();
            foreach(Comment comm in comms)
            {
                if(comm.CommentedEvent == id)
                {
                    foundComments.Add(comm);
                }
            }
            if(foundComments.Count == 0) {
                return View(m);
            }
            else
            {
                m.Comments = foundComments;
                return View(m);
            }
            
        }

        [HttpPost]
        public IActionResult Filter(int year, string search)
        {
            List<EventModel> eventModels = (List<EventModel>)_db.Event.GetAll();
            List<EventModel> searchedEvents = new List<EventModel>();
            if (search != null && year != 0)
            {
                string[] keywords = search.Split(" ");
                foreach (EventModel e in eventModels)
                {
                    string[] eventKeywords = e.EventName.Split(" ");
                    for (int i = 0; i < eventKeywords.Length; i++)
                    {
                        if (keywords.Contains(eventKeywords[i]))
                        {
                            searchedEvents.Add(e);
                        }
                    }
                }
                List<EventModel> filteredEvents = searchedEvents.Where(e => e.EventYear == year).ToList();
                return View("Index", filteredEvents);
            }else if(year != 0 && search==null)
            {

                List<EventModel> filteredEvents = eventModels.Where(e => e.EventYear == year).ToList();
                return View("Index", filteredEvents);
            }
            else if (search != null && year ==0)
            {
                string[] keywords = search.Split(" ");
                foreach (EventModel e in eventModels)
                {
                    string[] eventKeywords = e.EventName.Split(" ");
                    for (int i = 0; i < eventKeywords.Length; i++)
                    {
                        if (keywords.Contains(eventKeywords[i]))
                        {
                            searchedEvents.Add(e);
                        }
                    }
                }
                return View("Index", searchedEvents);
            }
            else
            {
                ViewBag.Message = "You didnt fill filters";
                return View("Index");
            }


             
        }
        [HttpPost]
        public IActionResult AddComment(int EventModel, string text)
        {
            var userName = User.Identity.Name;
            var user = _userManager.FindByNameAsync(userName).Result;
            EventModel e = _db.Event.Get(EventModel);
            Comment newComment = new Comment
            {
                Text = text,
                CommentedEvent = EventModel,
                Event = e,
                isReported = false,
                CommentOwner = user.Id,
                Owner=user
            };
            

            _db.Comment.Add(newComment);
            _db.Save();
    
            return RedirectToAction("ShowEvent", e);
        }

        [HttpPost]
        public IActionResult DeleteComment(int commentId)
        {
            Comment commentToDelete = _db.Comment.Get(commentId);
            EventModel e = _db.Event.Get(commentToDelete.CommentedEvent);

            _db.Comment.Delete(commentToDelete);
            _db.Save();
            return RedirectToAction("ShowEvent", e);
        }

        [HttpPost]
        public IActionResult ReportComment(int commentId)
        {
            Comment comment = _db.Comment.Get(commentId);
            comment.isReported = true;
            _db.Comment.Update(comment);
            _db.Save();
            EventModel e = _db.Event.Get(comment.CommentedEvent);
            return RedirectToAction("ShowEvent", e);
            
        }
        
    }
}
