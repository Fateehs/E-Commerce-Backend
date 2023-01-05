namespace ETradeAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddAsync(List<T> entity);
        Task<bool> Remove(T entity);
        Task<bool> Remove(string id);
        Task<bool> UpdateAsync(T entity);
    }
}
