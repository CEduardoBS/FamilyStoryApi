using FamilyStoryApi.Model;

namespace FamilyStoryApi.Business
{
    public interface IUserInfoBusiness
    {
        public bool Create(UserInfo userInfo);
        public bool Delete(UserInfo userInfo);
        public UserInfo GetById(int Id);
        public UserInfo Update(UserInfo userInfo);
    }
}
