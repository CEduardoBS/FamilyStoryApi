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

        public async Task<UserInfo> Create(UserInfo userInfo)
        {
            UserInfo? createdUser;

            try
            {
                await _userInfo.AddAsync(userInfo);
                await _dbContext.SaveChangesAsync();

                createdUser = await _userInfo
                    .AsNoTracking()
                    .Include(user => user.UserGroup)
                    .FirstOrDefaultAsync(user => user.Email.ToLower() == userInfo.Email.ToLower());

                if (createdUser is null)
                    throw new Exception(message: "Usuário não cadastrado");
            }
            catch (Exception)
            {
                throw;
            }

            return createdUser;
        }

        public async Task<int> Delete(UserInfo userInfo)
        {
            int rowsUpdate = 0;
            try
            {
                userInfo.IsDeleted = 1;

                _userInfo.Update(userInfo);
                rowsUpdate = await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return rowsUpdate;
        }

        public async Task<UserInfo> GetById(int id)
        {
            UserInfo? foundUser;
            try
            {
                foundUser = await _userInfo.AsNoTracking().FirstOrDefaultAsync(user => user.UserId == id);

                if (foundUser is null)
                    throw new Exception(message: "Usuário não encontrado");
            }
            catch (Exception)
            {
                throw;
            }

            return foundUser!;
        }

        public async Task<List<UserInfo>> GetRange(int skip = 0, int take = 10)
        {
            List<UserInfo> users = new();
            try
            {
                users = await _userInfo.AsNoTracking().Skip(skip).Take(take).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return users;
        }

        public async Task<UserInfo> Update(UserInfo userInfo)
        {
            UserInfo? updatedUser;
            try
            {
                _userInfo.Update(userInfo);
                await _dbContext.SaveChangesAsync();

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
