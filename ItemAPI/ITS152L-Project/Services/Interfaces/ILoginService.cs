using ItemDataLibrary.Models;

namespace ITS152L_Project.Services.Interfaces
{
    public interface ILoginService
    {

        Task<UserModel> GetByIdAsync(int id);

        Task<UserLogin?> LogAsync(UserLogin existingUser);

    }
}
