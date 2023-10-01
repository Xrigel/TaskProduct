namespace TaskBook.Core.Abstraction
{
    public interface IGenericRepository<T>where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetByID(int id);
        Task<bool> Delete(int id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
    }
}
