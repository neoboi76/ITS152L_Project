using ItemDataLibrary.Models;
using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Implementations;
using System;

/*

Developed by: 

    Ken Aliling
    Carl Norbi Felonia
    Cedrick Miguel Kaneko
    Amar Jacob Pajarito
    Dino Alfred Timbol

*/

//User repository that inherits from the generic repository and user repository interface.

namespace ITS152L_Project.Repositories.Interfaces
{
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
    {
        public UserRepository(ItemApiContext context) : base(context) { }
    }
}
