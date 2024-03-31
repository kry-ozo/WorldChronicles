using KronikiPodwalaV2.DataObjects;
using KronikiPodwalaV2.Repo.IRepo;

namespace KronikiPodwalaV2.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        public IEventRepo Event { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Event = new EventRepo(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
