/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * Interface for the IItemRepository. Promotes dependency injection
 * and loosely coupled relationships
 **/

using ItemDataLibrary.Models;

namespace ITS152L_Project.Repositories.Interfaces
{
    public interface IItemRepository: IRepository<ItemModel> { } //Extends Generic Interface Repository (uses generic CRUD repository operations)
}
