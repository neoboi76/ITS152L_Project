using ItemDataLibrary.Models;
using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Dapper.SqlMapper;

/*

Developed by: Dino Alfred T. Timbol

*/

//Item repository that inherits from the generic repository and item repository interface.

namespace ITS152L_Project.Repositories.Implementations
{
    public class LoginRepository : ILoginRepository
    {
        //Dependency Injection
        private readonly ItemApiContext _context;

        public LoginRepository(ItemApiContext context)
        {
            _context = context;
        }

        //Get's user id from the database
        public async Task<UserModel> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);


        }

        //Facilitates log in mechanism, verifying inputted credentials,
        //that is, if user exists in the database.
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


        //Facilitates resetting of user password in the database.
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
