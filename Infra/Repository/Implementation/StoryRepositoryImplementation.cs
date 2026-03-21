using FamilyStoryApi.Core.Interface.DataBase;
using FamilyStoryApi.Infra.Data;
using FamilyStoryApi.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamilyStoryApi.Infra.Repository.Implementation
{
    public class StoryRepositoryImplementation(FamilyStoryContext context) :
        RepositoryCRUD<Story>(context), IStoryRepository
    {
        private readonly FamilyStoryContext _context = context;
        private readonly DbSet<Story> _dbSet = context.Set<Story>();

        public async Task<Story> SoftDelete(Story info)
        {
            _dbSet.Update(info);
            await _context.SaveChangesAsync();

            return info;
        }
    }
}
