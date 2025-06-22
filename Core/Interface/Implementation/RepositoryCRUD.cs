using FamilyStoryApi.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace FamilyStoryApi.Core.Interface.Implementation
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

        public virtual async Task<T> Create(T info)
        {
            await _dbSetCRUD.AddAsync(info);
            await _contextCRUD.SaveChangesAsync();

            return info;
        }

        public virtual async Task<int> Delete(T info)
        {
            _dbSetCRUD.Remove(info);
            int rowsDeleted = await _contextCRUD.SaveChangesAsync();

            return rowsDeleted;
        }

        public virtual async Task<T?> GetById(int id)
        {
            T? objFound = await _dbSetCRUD.FindAsync(id);
            return objFound;
        }

        public virtual async Task<List<T>> GetRange(int skip = 0, int take = 10)
        {
            List<T> objects = await _dbSetCRUD
                .AsNoTracking()
                .OrderDescending()
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return objects;
        }

        public virtual async Task<T> SoftDelete(T info)
        {
            _dbSetCRUD.Update(info);
            await _contextCRUD.SaveChangesAsync();

            return info;
        }

        public virtual async Task<T> Update(T info)
        {
            _dbSetCRUD.Update(info);
            await _contextCRUD.SaveChangesAsync();

            return info;
        }
    }
}
