using KronikiPodwalaV2.DataObjects;
using KronikiPodwalaV2.Models;
using KronikiPodwalaV2.Repo;
using KronikiPodwalaV2.Repo.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KronikiPodwalaV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
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
        public IActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEvent(EventModel model)
        {
            _db.Event.Add(model);
            _db.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteEvent(EventModel model)
        {
            _db.Event.Delete(model);
            _db.Save();
            return RedirectToAction("Index");


        }

        public IActionResult EditEvent(int id)
        {
            EventModel e = _db.Event.Get(id);
            return View(e);
        }

        [HttpPost]
        public IActionResult EditEvent(EventModel model)
        {
            _db.Event.Update(model);
            _db.Save();
            return RedirectToAction("Index");
        }


    }




}
