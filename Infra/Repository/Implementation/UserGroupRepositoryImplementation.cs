using FamilyStoryApi.Core.Interface.DataBase;
using FamilyStoryApi.Infra.Data;
using FamilyStoryApi.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamilyStoryApi.Infra.Repository.Implementation
{
    public class UserGroupRepositoryImplementation(FamilyStoryContext context)
        : RepositoryCRUD<UserGroup>(context), IUserGroupRepository
    {
        private readonly FamilyStoryContext _context = context;
        private readonly DbSet<UserGroup> _dbSet = context.Set<UserGroup>();

        public async Task<UserGroup> SoftDelete(UserGroup entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
