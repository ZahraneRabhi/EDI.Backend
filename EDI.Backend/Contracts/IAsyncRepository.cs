namespace EDI.Backend.Contracts
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<IReadOnlyCollection<T>> ListAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
