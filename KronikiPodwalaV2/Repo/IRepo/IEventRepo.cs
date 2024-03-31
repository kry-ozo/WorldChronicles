using KronikiPodwalaV2.Models;

namespace KronikiPodwalaV2.Repo.IRepo
{
    public interface IEventRepo :IRepo<EventModel>
    {
        public void Update(EventModel e);
    }
}
