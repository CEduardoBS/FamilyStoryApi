using FamilyStoryApi.Model;

namespace FamilyStoryApi.Business
{
    public interface IUserInfoBusiness
    {
        public UserInfo Create(UserInfo userInfo);
        public bool Delete(int id);
        public UserInfo GetById(int id);
        public List<UserInfo> GetByRange(int skip = 0, int take = 10);
        public UserInfo Update(UserInfo userInfo);
    }
}
