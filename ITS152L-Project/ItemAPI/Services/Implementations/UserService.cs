using ItemDataLibrary.Models;
using ITS152L_Project.Repositories.Interfaces;
using ITS152L_Project.Services.Interfaces;
using ItemDataLibrary.Security;

/*

Developed by: 

    Ken Aliling
    Carl Norbi Felonia
    Cedrick Miguel Kaneko
    Amar Jacob Pajarito
    Dino Alfred Timbol

*/

//User service class. Handles business logic and communicates
//with the controllers and repositories associated with users.


namespace ITS152L_Project.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserModel> AddAsync(UserModel user)
        {
            // Hash the password before storing
            user.Password = PasswordHasher.HashPassword(user.Password);
            return await _repository.AddAsync(user);
        }

        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<UserModel?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UserModel user)
        {
            // If password is being updated, hash it
            if (!string.IsNullOrWhiteSpace(user.Password))
            {
                user.Password = PasswordHasher.HashPassword(user.Password);
            }
            await _repository.UpdateAsync(user);
        }
    }

}

