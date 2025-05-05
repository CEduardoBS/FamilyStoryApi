using FamilyStoryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FamilyStoryApi.Repository.Implementation
{
    public class UserInfoRepositoryImplementation : IUserInfoRepository
    {
        private readonly DbContext _dbContext;
        private DbSet<UserInfo> _userInfo;

        public UserInfoRepositoryImplementation(DbContext dbContext)
        {
            _dbContext = dbContext;
            _userInfo = dbContext.Set<UserInfo>();
        }

        public UserInfo Create(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public int Delete(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public UserInfo GetById(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public UserInfo Update(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }
    }
}
