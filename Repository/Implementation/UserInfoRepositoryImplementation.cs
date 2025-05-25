using FamilyStoryApi.Data;
using FamilyStoryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FamilyStoryApi.Repository.Implementation
{
    public class UserInfoRepositoryImplementation : IUserInfoRepository
    {
        private readonly FamilyStoryContext _dbContext;
        private DbSet<UserInfo> _userInfo;

        public UserInfoRepositoryImplementation(FamilyStoryContext dbContext)
        {
            _dbContext = dbContext;
            _userInfo = dbContext.Set<UserInfo>();
        }

        public UserInfo Create(UserInfo userInfo)
        {
            UserInfo? createdUser;

            try
            {
                _userInfo.Add(userInfo);
                _dbContext.SaveChanges();

                createdUser = _userInfo
                    .AsNoTracking()
                    .Include(user => user.UserGroup)
                    .FirstOrDefault(user => user.Email.ToLower() == userInfo.Email.ToLower());

                if (createdUser is null)
                    throw new Exception(message: "Usuário não cadastrado");
            }
            catch (Exception)
            {
                throw;
            }

            return createdUser;
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
            UserInfo? foundUser;
            try
            {
                foundUser = _userInfo.AsNoTracking().FirstOrDefault(user => user.UserId == id);

                if (foundUser is null)
                    throw new Exception(message: "Usuário não encontrado");
            }
            catch (Exception)
            {
                throw;
            }

            return foundUser!;
        }

        public List<UserInfo> GetRange(int skip = 0, int take = 10)
        {
            List<UserInfo> users = new();
            try
            {
                users = _userInfo.AsNoTracking().Skip(skip).Take(take).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return users;
        }

        public UserInfo Update(UserInfo userInfo)
        {
            UserInfo? updatedUser;
            try
            {
                _userInfo.Update(userInfo);
                _dbContext.SaveChanges();

                updatedUser = _userInfo
                    .AsNoTracking()
                    .Include(user => user.UserGroup)
                    .FirstOrDefault(user => user.Email.ToUpper() == userInfo.Email);

                if (updatedUser is null)
                    throw new Exception(message: "Usuário não atualizado");

            }
            catch (Exception)
            {
                throw;
            }

            return updatedUser;
        }
    }
}
