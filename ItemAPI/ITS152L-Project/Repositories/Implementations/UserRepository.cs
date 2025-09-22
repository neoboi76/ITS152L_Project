using ItemDataLibrary.Models;
using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Implementations;
using System;

namespace ITS152L_Project.Repositories.Interfaces
{
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
    {
        public UserRepository(ItemApiContext context) : base(context) { }
    }
}
