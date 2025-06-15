using FamilyStoryApi.Model;
using FamilyStoryApi.Repository;
using System.Linq.Expressions;

namespace FamilyStoryApi.Business.Implementation
{
    public class UserInfoBusinessImplementation(IUserInfoRepository userInfoRepository) : IUserInfoBusiness
    {
        private readonly IUserInfoRepository _userInfoRepository = userInfoRepository;

        public async Task<UserInfo> Create(UserInfo userInfo)
        {
            try
            {
                UserInfo userCreated = await _userInfoRepository.Create(userInfo);
                return userCreated;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                bool wasDeleted = false;

                UserInfo user = await _userInfoRepository.GetById(id);
                int qtdRowUpdated = await _userInfoRepository.Delete(user);

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

        public async Task<UserInfo> GetById(int id)
        {
            try
            {
                UserInfo user = await _userInfoRepository.GetById(id);
                return user;
            }
            catch
            {
                throw;
            }
            
        }

        public async Task<List<UserInfo>> GetByRange(int skip = 0, int take = 10)
        {
            try
            {
                List<UserInfo> users = new();
                users = await _userInfoRepository.GetRange(skip, take);

                return users;
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserInfo> Update(UserInfo userInfo)
        {
            try
            {
                UserInfo user = await _userInfoRepository.Update(userInfo);
                return user;
            }
            catch
            {
                throw;
            }    
        }
    }
}
