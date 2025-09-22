using ItemDataLibrary.Models;
using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<UserLogin> LogAsync(UserLogin realUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Password == realUser.Password);

            return realUser;
        }
    }
}
