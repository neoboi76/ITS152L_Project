using ItemDataLibrary.Models;
using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Interfaces;
using System;

/*

Developed by: Dino Alfred T. Timbol

*/

//Item repository that inherits from the generic repository and item repository interface.

namespace ITS152L_Project.Repositories.Implementations
{
    public class ItemRepository : GenericRepository<ItemModel>, IItemRepository
    {
        public ItemRepository(ItemApiContext context) : base(context) { }
    }

}
