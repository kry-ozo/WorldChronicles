using KronikiPodwalaV2.Models;

namespace KronikiPodwalaV2.Repo.IRepo
{
    public interface ICommentRepo:IRepo<Comment>
    {
        public void Update(Comment comment);
    }
}
