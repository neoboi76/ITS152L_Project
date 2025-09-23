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
