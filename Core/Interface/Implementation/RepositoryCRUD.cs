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
            try
            {
                await _dbSetCRUD.AddAsync(info);
                int rowsAdd = await _contextCRUD.SaveChangesAsync();

                if (rowsAdd < 1)
                {
                    throw new Exception(message: "Não foi possível salvar o registro!");
                }

                return info;
            }
            catch(Exception err)
            {
                throw new Exception("ENTF01|", err);
            }
        }

        public virtual async Task<int> Delete(T info)
        {
            try
            {
                _dbSetCRUD.Remove(info);
                int rowsDeleted = await _contextCRUD.SaveChangesAsync();

                if (rowsDeleted < 1)
                {
                    throw new Exception(message: "Não foi possível deleter o registro!");
                }

                return rowsDeleted;
            }
            catch (Exception err)
            {
                throw new(message: "ENTF02|", err);
            }
        }

        public virtual async Task<T> GetById(int id)
        {
            try
            {
                T? objFound = await _dbSetCRUD.FindAsync(id);
                
                if (objFound is null) 
                {
                    throw new Exception(message: "Não foi possível deleter o registro!");
                }

                return objFound;
            }
            catch (Exception err)
            {
                throw new(message: "ENTF03|", err);
            }
        }

        public virtual async Task<List<T>> GetRange(int skip = 0, int take = 10)
        {
            try
            {
                List<T> objects = await _dbSetCRUD
                    .AsNoTracking()
                    .OrderDescending()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

                return objects;
            }
            catch (Exception err)
            {
                throw new(message: "ENTF04|", err);
            }
        }

        public virtual async Task<T> Update(T info)
        {
            try
            {
                _dbSetCRUD.Update(info);
                await _contextCRUD.SaveChangesAsync();

                return info;
            }
            catch (Exception err)
            {
                throw new(message: "ENTF05|", err);

            }
        }
    }
}
