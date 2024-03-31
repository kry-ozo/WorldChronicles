using KronikiPodwalaV2.DataObjects;
using KronikiPodwalaV2.Models;
using KronikiPodwalaV2.Repo.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KronikiPodwalaV2.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize]
    public class EventsController : Controller
    {
        private readonly IUnitOfWork _db;
       

        public EventsController(IUnitOfWork db)
        {
            _db = db;
            
        }
        public IActionResult Index()
        {
            List<EventModel> eventModels = (List<EventModel>)_db.Event.GetAll();
            return View(eventModels);
        }
        public IActionResult ShowEvent(int id)
        {
            EventModel m = _db.Event.Get(id);
            return View(m);
        }
        [HttpPost]
        public IActionResult Filter(int year)
        {
            List<EventModel> eventModels = (List<EventModel>)_db.Event.GetAll();
            List<EventModel> filteredEvents = eventModels.Where(e => e.EventYear == year).ToList();
            return View("Index", filteredEvents);   
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            List<EventModel> eventModels = (List<EventModel>)_db.Event.GetAll();
            List<EventModel> searchedEvents  = new List<EventModel>();
            string[] keywords = search.Split(" ");
            foreach(EventModel e in eventModels)
            {
                string[] eventKeywords = e.EventName.Split(" ");
                for(int i = 0; i<eventKeywords.Length; i++)
                {
                    if (keywords.Contains(eventKeywords[i]))
                    {
                        searchedEvents.Add(e);
                    }
                }
            }
            return View("Index", searchedEvents);
        }

    }
}
