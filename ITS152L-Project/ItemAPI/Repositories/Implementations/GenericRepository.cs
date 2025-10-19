using ITS152L_Project.Repositories.Interfaces;
using ITS152L_Project.Data;
using Microsoft.EntityFrameworkCore;

/*

Developed by: Dino Alfred T. Timbol

*/

//Generic repository that defines methods to be inherited
//By the item and user repositories.

namespace ITS152L_Project.Repositories.Implementations
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        //Dependency Injection
        private readonly ItemApiContext _context;

        //Since model is unknown during runtime
        //this will be modified accordingly depending
        //on the model that is used or specified
        private readonly DbSet<T> _dbSet;

        //Dependency Injection
        public GenericRepository(ItemApiContext context) 
        { 
            _context = context;
            _dbSet = _context.Set<T>();
        
        }

        //Adds user or item to the database
        public async Task<T> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        //Deletes user or item from the database
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        //Gets all items or users from the database
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        //Gets a specific user or item from the database
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);

        }

        //Modifies a particular user or item in the database
        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;

        }

    }
}
