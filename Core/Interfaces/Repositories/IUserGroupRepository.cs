using FamilyStoryApi.Infra.Entities;

namespace FamilyStoryApi.Core.Interface.DataBase
{
    public interface IUserGroupRepository : IRepositoryCRUD<UserGroup>
    {
        Task<UserGroup> SoftDelete(UserGroup entity);
    }
}
