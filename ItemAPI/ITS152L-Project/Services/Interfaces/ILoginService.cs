using ItemDataLibrary.Models;

/*

Developed by: Dino Alfred T. Timbol

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
