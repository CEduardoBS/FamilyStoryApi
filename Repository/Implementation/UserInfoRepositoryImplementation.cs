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
            UserInfo userCreated;

            try
            {
                _userInfo.Add(userInfo);
                _dbContext.SaveChanges();

                userCreated = _userInfo
                    .AsNoTracking()
                    .Include(user => user.UserGroup)
                    .First(user => user.Email.ToUpper() == userInfo.Email);
            }
            catch (Exception)
            {
                throw;
            }

            return userCreated;
        }

        public int Delete(UserInfo userInfo)
        {
            int rowsUpdate = 0;
            try
            {
                userInfo.IsDeleted = 1;

                _userInfo.Update(userInfo);
                rowsUpdate = _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return rowsUpdate;
        }

        public UserInfo GetById(int id)
        {
            UserInfo userFound;
            try
            {
                userFound = _userInfo.AsNoTracking().First(user => user.UserId == id);
            }
            catch (Exception)
            {
                throw;
            }

            return userFound;
        }

        public UserInfo Update(UserInfo userInfo)
        {
            UserInfo userUpdated;
            try
            {
                _userInfo.Update(userInfo);
                _dbContext.SaveChanges();

                userUpdated = _userInfo
                    .AsNoTracking()
                    .Include(user => user.UserGroup)
                    .First(user => user.Email.ToUpper() == userInfo.Email);
            }
            catch (Exception)
            {
                throw;
            }

            return userUpdated;
        }
    }
}
