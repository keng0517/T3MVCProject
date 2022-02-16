namespace T3MVCProject.Services
{
    public interface IRepo<K, T> : IAdding<K, T>
    {
        ICollection<T> GetAll();
        T Get(K username);

        
        bool Remove(K username);
        bool Update(T item);

        
    }
}
