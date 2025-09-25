using ItemDataLibrary.Models;

/*

Developed by: Dino Alfred T. Timbol

*/

//User Service Interface

namespace ITS152L_Project.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<UserModel?> GetByIdAsync(int id);
        Task<UserModel> AddAsync(UserModel user);
        Task UpdateAsync(UserModel user);
        Task DeleteAsync(int id);
    }
}
