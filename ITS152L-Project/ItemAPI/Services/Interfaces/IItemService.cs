using ItemDataLibrary.Models;

/*

Developed by: 

    Ken Aliling
    Carl Norbi Felonia
    Cedrick Miguel Kaneko
    Amar Jacob Pajarito
    Dino Alfred Timbol

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
