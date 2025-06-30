using FamilyStoryApi.Core.Interface;
using FamilyStoryApi.Infra.Entities;

namespace FamilyStoryApi.Infra.Repository
{
    public interface IUserInfoRepository : IRepositoryCRUD<UserInfo>
    {
        Task<UserInfo?> GetUserByEmail(string email);
        Task<UserInfo?> GetUserFullInfo(int id);
    }
}
