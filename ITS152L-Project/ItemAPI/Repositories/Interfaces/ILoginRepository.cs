/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * Interface for the ILoginRepository. Promotes dependency injection
 * and loosely coupled relationships
 **/

using ItemDataLibrary.Models;

namespace ITS152L_Project.Repositories.Interfaces
{
    public interface ILoginRepository
    {

        Task<UserModel> GetByIdAsync(int id);
        Task<UserModel> LogAsync(UserLogin realUser);

        Task<UserModel> ResAsync(UserLogin existingUser);

    }
}
