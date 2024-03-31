using KronikiPodwalaV2.DataObjects;
using KronikiPodwalaV2.Models;
using KronikiPodwalaV2.Repo.IRepo;

namespace KronikiPodwalaV2.Repo
{
    public class EventRepo : Repo<EventModel>, IEventRepo
    {
        private readonly AppDbContext _db;

        public EventRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(EventModel e)
        {
            _db.Update(e);
        }
    }
}
