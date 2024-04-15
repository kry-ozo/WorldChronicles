using KronikiPodwalaV2.DataObjects;
using KronikiPodwalaV2.Models;
using KronikiPodwalaV2.Repo.IRepo;

namespace KronikiPodwalaV2.Repo
{
    public class CommentRepo : Repo<Comment>, ICommentRepo
    {
        private readonly AppDbContext _db;
        public CommentRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Comment comment)
        {
            _db.Update(comment);
        }
    }
}
