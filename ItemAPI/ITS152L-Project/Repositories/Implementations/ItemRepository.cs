using ItemDataLibrary.Models;
using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Interfaces;
using System;

namespace ITS152L_Project.Repositories.Implementations
{
    public class ItemRepository : GenericRepository<ItemModel>, IItemRepository
    {
        public ItemRepository(ItemApiContext context) : base(context) { }
    }

}
