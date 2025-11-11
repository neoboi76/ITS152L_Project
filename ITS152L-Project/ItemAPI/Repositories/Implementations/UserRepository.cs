/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * UserRepository class. Deals with item related
 * database operations
 **/

using ItemDataLibrary.Models;
using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Implementations;
using System;

namespace ITS152L_Project.Repositories.Interfaces
{
    public class UserRepository : GenericRepository<UserModel>, IUserRepository //Extends Generic Repository (uses generic CRUD repository operations)
    {
        public UserRepository(ItemApiContext context) : base(context) { }
    }
}
