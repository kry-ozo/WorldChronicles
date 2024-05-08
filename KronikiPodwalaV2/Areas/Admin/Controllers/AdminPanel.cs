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
    public class AdminPanel : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly AppDbContext _appDbContext;

        public AdminPanel(IUnitOfWork db, AppDbContext appDbContext)
        {
            _db = db;
            _appDbContext = appDbContext;
        }
        public IActionResult ManageEvents(string message="")
        {
            ViewData["AdminMessage"] = message;
            return View();
        }
        public IActionResult ManageComments(int id)
        {
            if(id!=0|| id != null)
            {
                List<Comment> comments = (List<Comment>)_db.Comment.GetAll();
                return View(comments);
            }
            else
            {
                return RedirectToAction("ManageEvents");
            }
          
        }
        public IActionResult ManageReportedComments()
        {
            List<Comment> comments = (List<Comment>)_db.Comment.GetAll();
            return View(comments); 
        }
        public IActionResult ManageUsers()
        {
            List<AppUser> users = _appDbContext.Users.ToList();
            return View(users);
        }

        public IActionResult DeleteOrEditEvents() {
            List<EventModel> events = (List<EventModel>)_db.Event.GetAll();
            return View(events);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteEvent(EventModel e)
        {
            if (e.Id!=0)
            {
                _db.Event.Delete(e);

                _db.Save();
                return RedirectToAction("DeleteOrEditEvents");
            }
            else
            {
                return RedirectToAction("ManageEvents", new { message = "Event couldnt be deleted" });
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult AddEvent(EventModel e)
        {
            ViewData["AdminMessage"] = "";
            if (e.EventName!=null && e.EventDescription!=null && e.EventYear!=0)
            {
                _db.Event.Add(e);
                _db.Save();
                return RedirectToAction("ManageEvents");
            }
            else
            {
                
                 return RedirectToAction("ManageEvents", new { message = "Event couldnt be added" });
            }
        }
           
        

        
        public IActionResult EditEvent(int Id)
        {
            if(Id != 0|| Id != null)
            {
                EventModel e = _db.Event.Get(Id);
                return View(e);
            }
            else
            {
                return RedirectToAction("ManageEvents");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult EditEvent(EventModel e)
        {
            if(e.EventName != null && e.EventDescription != null && e.EventYear != 0)
            {
                _db.Event.Update(e);
                _db.Save();
                return RedirectToAction("DeleteOrEditEvents");
            }
            else
            {
                
                return RedirectToAction("ManageEvents", new {message = "Event couldnt be edited" });
            }


           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteComment(int Id)
        {
            if (Id != null || Id != 0)
            {
                Comment comment = _db.Comment.Get(Id);
                _db.Comment.Delete(comment);
                _db.Save();
                return RedirectToAction("ManageReportedComments");
            }
            else
            {
                return RedirectToAction("ManageEvents", new { message = "Comment couldnt be deleted" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteReportedComment(int Id)
        {
            if(Id!=null|| Id!=0)
            {
                Comment comment = _db.Comment.Get(Id);
                _db.Comment.Delete(comment);
                _db.Save();
                return RedirectToAction("ManageReportedComments");
            }
            else
            {
                return RedirectToAction("ManageEvents", new { message = "Comment couldnt be deleted" });
            }
            
        }
    }




}
