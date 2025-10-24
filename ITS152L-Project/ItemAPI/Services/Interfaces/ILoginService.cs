using ItemDataLibrary.Models;

/*

Developed by: 

    Ken Aliling
    Carl Norbi Felonia
    Cedrick Miguel Kaneko
    Amar Jacob Pajarito
    Dino Alfred Timbol

*/

//Login Service Interface

namespace ITS152L_Project.Services.Interfaces
{
    public interface ILoginService
    {

        Task<UserModel> GetByIdAsync(int id);

        Task<UserModel> LogAsync(UserLogin existingUser);

        Task<UserModel> ResAsync(UserLogin existingUser);

    }
}
