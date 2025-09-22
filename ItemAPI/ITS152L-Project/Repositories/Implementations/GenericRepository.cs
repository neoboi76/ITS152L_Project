using ITS152L_Project.Repositories.Interfaces;
using ITS152L_Project.Data;
using Microsoft.EntityFrameworkCore;

namespace ITS152L_Project.Repositories.Implementations
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        private readonly ItemApiContext _context;
        private readonly DbSet<T> _dbSet;


        public GenericRepository(ItemApiContext context) 
        { 
            _context = context;
            _dbSet = _context.Set<T>();
        
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);

        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

        }
    }
}
