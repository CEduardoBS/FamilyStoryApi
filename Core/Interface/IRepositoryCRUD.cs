namespace FamilyStoryApi.Core.Interface
{
    public interface IRepositoryCRUD<T>
    {
        public T Create(T userInfo);

        public T Update(T userInfo);

        public int Delete(T userInfo);

        public T GetById(int id);

        public List<T> GetRange(int skip = 0, int take = 10);
    }
}
