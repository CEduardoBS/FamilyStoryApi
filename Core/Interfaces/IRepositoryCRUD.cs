namespace FamilyStoryApi.Core.Interface
{
    public interface IRepositoryCRUD<T> where T : class
    {
        Task<T> Create(T info);
        Task<T> Update(T info);
        Task<int> Delete(T info);
        Task<T> SoftDelete(T info);
        Task<T?> GetById(int id);
        Task<List<T>> GetRange(int skip = 0, int take = 10);
    }
}
