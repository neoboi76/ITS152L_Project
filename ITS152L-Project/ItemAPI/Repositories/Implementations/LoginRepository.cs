using ItemDataLibrary.Models;
using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Dapper.SqlMapper;
using ItemDataLibrary.Security;

/*

Developed by: 

    Ken Aliling
    Carl Norbi Felonia
    Cedrick Miguel Kaneko
    Amar Jacob Pajarito
    Dino Alfred Timbol

*/

//Item repository that inherits from the generic repository and item repository interface.

namespace ITS152L_Project.Repositories.Implementations
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ItemApiContext _context;

        public LoginRepository(ItemApiContext context)
        {
            _context = context;
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<UserModel> LogAsync(UserLogin realUser)
        {
            // First, find user by username
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == realUser.UserName);

            if (user == null)
            {
                return null;
            }

            // Verify the password against the stored hash
            if (PasswordHasher.VerifyPassword(realUser.Password, user.Password))
            {
                return user;
            }

            return null;
        }

        public async Task<UserModel> ResAsync(UserLogin existingUser)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == existingUser.UserName);

            if (user != null)
            {
                // Hash the new password before saving
                user.Password = PasswordHasher.HashPassword(existingUser.Password);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }

            return null;
        }
    }
}
