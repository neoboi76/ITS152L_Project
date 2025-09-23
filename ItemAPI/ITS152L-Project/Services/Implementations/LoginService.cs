using ItemDataLibrary.Models;
using ITS152L_Project.Repositories.Interfaces;
using ITS152L_Project.Services;
using ITS152L_Project.Services.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace ITS152L_Project.Services.Implementations
{
    public class LoginService : ILoginService
    {

        private readonly ILoginRepository _repository; 

        public LoginService(ILoginRepository repository)
        {
            _repository = repository; 
        }

        public Task<UserModel> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<UserModel> LogAsync(UserLogin existingUser)
        {
            var user = _repository.LogAsync(existingUser);

            return user;
        }
        public Task<UserModel> ResAsync(UserLogin existingUser)
        {
            var user = _repository.ResAsync(existingUser);

            if (user != null)
            {
                return user;
            }

            return null;
        }

    }
}
