using ItemDataLibrary.Models;

/*

Developed by: Dino Alfred T. Timbol

*/

//Log in Repository Interface

namespace ITS152L_Project.Repositories.Interfaces
{
    public interface ILoginRepository
    {

        Task<UserModel> GetByIdAsync(int id);
        Task<UserModel> LogAsync(UserLogin realUser);

        Task<UserModel> ResAsync(UserLogin existingUser);

    }
}
