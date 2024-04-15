namespace KronikiPodwalaV2.Repo.IRepo
{
    public interface IUnitOfWork
    {
        public IEventRepo Event{get;}
        public ICommentRepo Comment { get;}
        void Save();
    }
}
