/**
 * Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 *
 * Interface for the IRepository. 
 * Generic interface that is inherited by the User, Item, and
 * Audit log interfaces (not including Log in interface)
 * Promotes dependency injection and loosely coupled relationships
 **/


using ItemDataLibrary.Models;

namespace ITS152L_Project.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
