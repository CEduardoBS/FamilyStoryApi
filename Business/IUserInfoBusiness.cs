using FamilyStoryApi.Model;

namespace FamilyStoryApi.Business
{
    public interface IUserInfoBusiness
    {
        public Task<UserInfo> Create(UserInfo userInfo);
        public Task<bool> Delete(int id);
        public Task<UserInfo> GetById(int id);
        public Task<List<UserInfo>> GetByRange(int skip = 0, int take = 10);
        public Task<UserInfo> Update(UserInfo userInfo);
    }
}
