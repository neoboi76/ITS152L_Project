using ItemDataLibrary.Models;
using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ItemDataLibrary.Security;
using System.Threading.Tasks;

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
            string normalizedEmail = realUser.UserName.Trim().ToLowerInvariant();
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == normalizedEmail);

            if (user == null)
                return null;

            if (PasswordHasher.VerifyPassword(realUser.Password, user.Password))
                return user;

            return null;
        }

        public async Task<UserModel> ResAsync(UserLogin existingUser)
        {
            string normalizedEmail = existingUser.UserName.Trim().ToLowerInvariant();
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == normalizedEmail);

            if (user != null)
            {
                user.Password = PasswordHasher.HashPassword(existingUser.Password);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }

            return null;
        }
    }
}
