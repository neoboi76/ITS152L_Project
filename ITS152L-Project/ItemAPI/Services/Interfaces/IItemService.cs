using ItemDataLibrary.Models;

/*

Developed by: Dino Alfred T. Timbol

*/

//Item Service Interface

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
