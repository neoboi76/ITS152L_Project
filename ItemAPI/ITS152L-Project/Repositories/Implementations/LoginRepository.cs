using ItemDataLibrary.Models;
using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Dapper.SqlMapper;

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
            var user = await _context.Users
                                        .FirstOrDefaultAsync(u => u.UserName == realUser.UserName
                                                               && u.Password == realUser.Password);

            if (user == null)
            {
                return null;
            }

            return user; 
        }


        public async Task<UserModel> ResAsync(UserLogin existingUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == existingUser.UserName);


            if (user != null)

            {
                user.Password = existingUser.Password;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return user;
            }

            return null;
        }


    }
}
