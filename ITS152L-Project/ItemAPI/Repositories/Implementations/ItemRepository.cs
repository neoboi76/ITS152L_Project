/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * ItemRepository class. Deals with item related
 * database operations
 **/

using ItemDataLibrary.Models;
using ITS152L_Project.Data;
using ITS152L_Project.Repositories.Interfaces;
using System;

namespace ITS152L_Project.Repositories.Implementations
{
    public class ItemRepository : GenericRepository<ItemModel>, IItemRepository //Extends Generic Repository (uses generic CRUD repository operations)
    {
        public ItemRepository(ItemApiContext context) : base(context) { }
    }

}
