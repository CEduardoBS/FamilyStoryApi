using FamilyStoryApi.Infra.Entities;

namespace FamilyStoryApi.Core.Interface.DataBase
{
    public interface IStoryRepository : IRepositoryCRUD<Story>
    {
        Task<Story> SoftDelete(Story entity);
    }
}
