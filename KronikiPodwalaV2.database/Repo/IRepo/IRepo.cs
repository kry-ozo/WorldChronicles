namespace KronikiPodwalaV2.Repo.IRepo
{
    public interface IRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Delete(T item);
        void Add (T item);
    }
}
