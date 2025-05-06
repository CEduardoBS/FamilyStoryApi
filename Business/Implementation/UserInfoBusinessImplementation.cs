using FamilyStoryApi.Model;
using FamilyStoryApi.Repository;

namespace FamilyStoryApi.Business.Implementation
{
    public class UserInfoBusinessImplementation : IUserInfoBusiness
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public UserInfoBusinessImplementation(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public bool Create(UserInfo userInfo)
        {
            try
            {
                _userInfoRepository.Create(userInfo);
            }
            catch (Exception)
            {
                throw;
            }
            throw new NotImplementedException();
        }

        public bool Delete(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public UserInfo GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public UserInfo Update(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }
    }
}
