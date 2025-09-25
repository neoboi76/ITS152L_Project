using ItemDataLibrary.Models;
using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Implementations;
using System;

/*

Developed by: Dino Alfred T. Timbol

*/

//User repository that inherits from the generic repository and user repository interface.

namespace ITS152L_Project.Repositories.Interfaces
{
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
    {
        public UserRepository(ItemApiContext context) : base(context) { }
    }
}
