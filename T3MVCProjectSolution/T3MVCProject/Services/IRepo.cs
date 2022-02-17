namespace T3MVCProject.Services
{
    public interface IRepo<K, T> : IAdding<K, T>
    {
        ICollection<T> GetAll();

        T Get(K username); //Raindy

        //T Get(K id);  //duplicate

        T GetById(K id); // Halim

        bool Remove(K username);
        bool Update(T item);
		ICollection<T> GetSpecific(K k); //lp
        T Add(T item); //lp
        
    }
}
