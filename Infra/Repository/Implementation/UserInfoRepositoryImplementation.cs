using FamilyStoryApi.Core.Interface.DataBase;
using FamilyStoryApi.Domain.ValueObjects;
using FamilyStoryApi.Infra.Data;
using FamilyStoryApi.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamilyStoryApi.Infra.Repository.Implementation
{
    public class UserInfoRepositoryImplementation(FamilyStoryContext dbContext) :
        RepositoryCRUD<UserInfo>(context: dbContext),
        IUserInfoRepository
    {
        private readonly FamilyStoryContext _context = dbContext;
        private readonly DbSet<UserInfo> _dbSet = dbContext.Set<UserInfo>();

        public async Task<UserInfo> SoftDelete(UserInfo entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<UserInfo?> GetUserByEmail(string email)
        {
            UserInfo? userInfo = await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Email.ToLower().Equals(email.ToLower()));

            return userInfo;
        }

        public async Task<UserInfo?> GetUserFullInfo(int id)
        {
            UserInfo? userInfo = await _dbSet
                .AsNoTracking()
                .Include(user => user.UserGroup)
                    .ThenInclude(group => group.UserGroupPermissions)
                        .ThenInclude(permissions => permissions.Permission)
                .FirstOrDefaultAsync(user => user.UserId == id);

            return userInfo;
        }
    }
}
