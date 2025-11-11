/**
 * Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * Interface for the IUserService. Promotes dependency injection
 * and loosely coupled relationships
 **/

using ItemDataLibrary.Models;

namespace ITS152L_Project.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<UserModel?> GetByIdAsync(int id);
        Task<UserModel?> GetByEmailAsync(string email);
        Task<UserModel> AddAsync(UserModel user);
        Task UpdateAsync(UserModel user);
        Task DeleteAsync(int id);
    }
}