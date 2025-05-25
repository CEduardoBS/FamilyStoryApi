using FamilyStoryApi.Model;
using FamilyStoryApi.Repository;
using System.Linq.Expressions;

namespace FamilyStoryApi.Business.Implementation
{
    public class UserInfoBusinessImplementation : IUserInfoBusiness
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public UserInfoBusinessImplementation(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public UserInfo Create(UserInfo userInfo)
        {
            try
            {
                UserInfo userCreated = _userInfoRepository.Create(userInfo);
                return userCreated;
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                bool wasDeleted = false;

                UserInfo user = _userInfoRepository.GetById(id);
                int qtdRowUpdated = _userInfoRepository.Delete(user);

                if (qtdRowUpdated > 0)
                {
                    wasDeleted = true;
                }

                return wasDeleted;
            }
            catch
            {
                throw;
            }

        }

        public UserInfo GetById(int id)
        {
            try
            {
                UserInfo user = _userInfoRepository.GetById(id);
                return user;
            }
            catch
            {
                throw;
            }
            
        }

        public List<UserInfo> GetByRange(int skip = 0, int take = 10)
        {
            try
            {
                List<UserInfo> users = new();
                users = _userInfoRepository.GetRange(skip, take);

                return users;
            }
            catch
            {
                throw;
            }
        }

        public UserInfo Update(UserInfo userInfo)
        {
            try
            {
                UserInfo user = _userInfoRepository.Update(userInfo);
                return user;
            }
            catch
            {
                throw;
            }    
        }
    }
}
