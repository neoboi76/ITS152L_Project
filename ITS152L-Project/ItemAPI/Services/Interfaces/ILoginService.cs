
/**
 * Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * Interface for the ILoginService. Promotes dependency injection
 * and loosely coupled relationships
 **/

using ItemDataLibrary.Models;

namespace ITS152L_Project.Services.Interfaces
{
    public interface ILoginService
    {

        Task<UserModel> GetByIdAsync(int id);

        Task<UserModel> LogAsync(UserLogin existingUser);

        Task<UserModel> ResAsync(UserLogin existingUser);

    }
}
