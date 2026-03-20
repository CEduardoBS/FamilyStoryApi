using FamilyStoryApi.Infra.Entities;

namespace FamilyStoryApi.Core.Interface.DataBase
{
    public interface IUserInfoRepository : IRepositoryCRUD<UserInfo>
    {
        Task<UserInfo?> GetUserByEmail(string email);
        Task<UserInfo?> GetUserFullInfo(int id);
    }
}
