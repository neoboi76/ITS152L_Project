using ItemDataLibrary.Models;
using ITS152L_Project.Repositories.Interfaces;
using ITS152L_Project.Services.Interfaces;

namespace ITS152L_Project.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<UserModel> AddAsync(UserModel user)
        {
            return _repository.AddAsync(user);
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

        public Task UpdateAsync(UserModel user)
        {
            return _repository.UpdateAsync(user);
        }
    }
}
