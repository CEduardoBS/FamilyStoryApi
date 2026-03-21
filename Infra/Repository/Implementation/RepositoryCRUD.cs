using FamilyStoryApi.Core.Interface;
using FamilyStoryApi.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace FamilyStoryApi.Infra.Repository.Implementation
{
    public class RepositoryCRUD<T> : IRepositoryCRUD<T> where T : class
    {
        protected readonly FamilyStoryContext _contextCRUD;
        protected readonly DbSet<T> _dbSetCRUD;

        public RepositoryCRUD(FamilyStoryContext context)
        {
            _contextCRUD = context;
            _dbSetCRUD = _contextCRUD.Set<T>();
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _dbSetCRUD.AddAsync(entity);
            await _contextCRUD.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            _dbSetCRUD.Remove(entity);
            int rowsDeleted = await _contextCRUD.SaveChangesAsync();

            return rowsDeleted;
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            T? objFound = await _dbSetCRUD.FindAsync(id);
            return objFound;
        }

        public virtual async Task<List<T>> GetRangeAsync(int skip = 0, int take = 10)
        {
            List<T> objects = await _dbSetCRUD
                .AsNoTracking()
                .OrderDescending()
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return objects;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbSetCRUD.Update(entity);
            await _contextCRUD.SaveChangesAsync();

            return entity;
        }
    }
}
