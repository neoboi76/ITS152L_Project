/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * Interface for the IItemService. Promotes dependency injection
 * and loosely coupled relationships
 **/

using ItemDataLibrary.Models;

namespace ITS152L_Project.Services.Interfaces
{
    public interface IItemService
    {

        Task<IEnumerable<ItemModel>> GetAllAsync();
        Task<ItemModel?> GetByIdAsync(int id);
        Task<ItemModel> AddAsync(ItemModel item);
        Task<ItemModel> UpdateAsync(ItemModel updatedItem);
        Task DeleteAsync(int id);

    }
}
