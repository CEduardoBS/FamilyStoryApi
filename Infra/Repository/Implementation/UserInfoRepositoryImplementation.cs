using FamilyStoryApi.Core.Interface.Implementation;
using FamilyStoryApi.Infra.Data;
using FamilyStoryApi.Infra.Entities;
using FamilyStoryApi.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace FamilyStoryApi.Infra.Repository.Implementation
{
    public class UserInfoRepositoryImplementation(FamilyStoryContext dbContext) :
        RepositoryCRUD<UserInfo>(dbContext),
        IUserInfoRepository
    {
        public override async Task<UserInfo> Create(UserInfo userInfo)
        {
            await base.Create(userInfo);
            return userInfo;
        }

        public override async Task<int> Delete(UserInfo userInfo)
        {
            int qtdRowsDeleted = await base.Delete(userInfo);
            return qtdRowsDeleted;
        }

        public override async Task<UserInfo> SoftDelete(UserInfo userInfo)
        {
            UserInfo updatedUser = await base.Update(userInfo);
            return updatedUser;
        }

        public override async Task<UserInfo?> GetById(int id)
        {
            UserInfo? foundUser = await base.GetById(id);
            return foundUser;
        }

        public override async Task<List<UserInfo>> GetRange(int skip = 0, int take = 10)
        {
            List<UserInfo> users = [];
            users = await base.GetRange(skip, take);

            return users;
        }

        public override async Task<UserInfo> Update(UserInfo userInfo)
        {
            UserInfo updatedUser = await base.Update(userInfo);
            return updatedUser;
        }
    }
}
