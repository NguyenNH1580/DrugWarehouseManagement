using DrugWarehouseManagement_API.Data;
using DrugWarehouseManagement_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrugWarehouseManagement_API.Repositories
{
    public class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        private readonly DrugHousewareManagementDbContext _context;
        public CommonRepository(DrugHousewareManagementDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            var x = await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
