/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * UserService class. Deals with user authentication operations
 * and admin user management operation
 **/

using ItemDataLibrary.Models;
using ITS152L_Project.Repositories.Interfaces;
using ITS152L_Project.Services.Interfaces;
using ITS152L_Project.Data;
using ItemDataLibrary.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ITS152L_Project.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ItemApiContext _context;

        public UserService(IUserRepository repository, ItemApiContext context)
        {
            _repository = repository;
            _context = context;
        }

        //Registers a user
        public async Task<UserModel> AddAsync(UserModel user)
        {
            user.UserName = user.UserName.Trim().ToLowerInvariant();

            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == user.UserName);

            if (existingUser != null)
            {
                throw new InvalidOperationException(
                    $"An account with the email '{user.UserName}' already exists. " +
                    "Please use a different email address.");
            }

            if (!IsValidEmail(user.UserName))
            {
                throw new ArgumentException("Invalid email address format.");
            }

            user.Password = PasswordHasher.HashPassword(user.Password);

            try
            {
                return await _repository.AddAsync(user);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("duplicate") == true ||
                    ex.InnerException?.Message.Contains("IX_Users_UserName_Unique") == true)
                {
                    throw new InvalidOperationException(
                        $"An account with the email '{user.UserName}' already exists. " +
                        "Please use a different email address.");
                }
                throw;
            }
        }

        //Deletes a user
        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        //Retrieves all registered users
        public Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        //Retrieves a particular user by id
        public Task<UserModel?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        //Retrieves a particular user by email
        public async Task<UserModel?> GetByEmailAsync(string email)
        {
            string normalizedEmail = email.Trim().ToLowerInvariant();
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == normalizedEmail);
        }

        //Updates user information (e.g. Resetting password)
        public async Task UpdateAsync(UserModel user)
        {
            user.UserName = user.UserName.Trim().ToLowerInvariant();

            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == user.UserName && u.Id != user.Id);

            if (existingUser != null)
            {
                throw new InvalidOperationException(
                    $"An account with the email '{user.UserName}' already exists.");
            }

            if (!string.IsNullOrWhiteSpace(user.Password))
            {
                user.Password = PasswordHasher.HashPassword(user.Password);
            }

            try
            {
                await _repository.UpdateAsync(user);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("duplicate") == true ||
                    ex.InnerException?.Message.Contains("IX_Users_UserName_Unique") == true)
                {
                    throw new InvalidOperationException(
                        $"An account with the email '{user.UserName}' already exists.");
                }
                throw;
            }
        }

        //Checks if email format is valid or not
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
