using ItemDataLibrary.Models;

/*

Developed by: 

    Ken Aliling
    Carl Norbi Felonia
    Cedrick Miguel Kaneko
    Amar Jacob Pajarito
    Dino Alfred Timbol

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
