using KronikiPodwalaV2.DataObjects;
using KronikiPodwalaV2.Repo.IRepo;
using Microsoft.EntityFrameworkCore;

namespace KronikiPodwalaV2.Repo
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> _dbSet;
        public Repo(AppDbContext db) { 
            _db = new AppDbContext();
            this._dbSet = db.Set<T>();
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public void Delete(T item)
        {
            _dbSet.Remove(item);
        }

        public T Get(int id)
        {
           return  _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
