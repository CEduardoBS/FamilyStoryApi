namespace FamilyStoryApi.Core.Interface
{
    public interface IRepositoryCRUD<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetRangeAsync(int skip = 0, int take = 10);
    }
}
