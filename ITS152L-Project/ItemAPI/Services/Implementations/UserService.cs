using ItemDataLibrary.Models;
using ITS152L_Project.Repositories.Interfaces;
using ITS152L_Project.Services.Interfaces;

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
        
        //Dependency Injection
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        //Adds a user to the repository
        public Task<UserModel> AddAsync(UserModel user)
        {
            return _repository.AddAsync(user);
        }

        //Deletes a user from the repository
        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        //Gets all users from the repository
        public Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        //Gets a specific user via the repository
        public Task<UserModel?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        //Modifies information about a user through the repository
        public Task UpdateAsync(UserModel user)
        {
            return _repository.UpdateAsync(user);
        }
    }
}
