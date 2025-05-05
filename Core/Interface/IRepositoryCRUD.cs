namespace FamilyStoryApi.Core.Interface
{
    public interface IRepositoryCRUD<T>
    {
        public T Create(T userInfo);

        public T Update(T userInfo);

        public int Delete(T userInfo);

        public T GetById(T userInfo);
    }
}
