/**
 * Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * Log in service class. Handles business logic and communicates
 * with the controllers and repositories associated with the log in functionality
 **/


using ItemDataLibrary.Models;
using ITS152L_Project.Repositories.Interfaces;
using ITS152L_Project.Services;
using ITS152L_Project.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITS152L_Project.Services.Implementations
{
    public class LoginService : ILoginService
    {

        //Dependency Injection
        private readonly ILoginRepository _repository; 

        public LoginService(ILoginRepository repository)
        {
            _repository = repository; 
        }

        //Gets a specific user through the repository
        public Task<UserModel> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        //Facilitates log in mechanism, verifying inputted credentials,
        //that is, if user exists in the database.
        public Task<UserModel> LogAsync(UserLogin existingUser)
        {
            var user = _repository.LogAsync(existingUser);

            return user;
        }

        //Facilitates the resetting of user password.
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
