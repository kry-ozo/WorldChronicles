namespace KronikiPodwalaV2.Repo.IRepo
{
    public interface IUnitOfWork
    {
        public IEventRepo Event{get;}
        void Save();
    }
}
