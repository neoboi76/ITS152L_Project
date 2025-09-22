using ItemDataLibrary.Models;

namespace ITS152L_Project.Services.Interfaces
{
    public interface IItemService
    {

        Task<IEnumerable<ItemModel>> GetAllAsync();
        Task<ItemModel?> GetByIdAsync(int id);
        Task<ItemModel> AddAsync(ItemModel item);
        Task UpdateAsync(ItemModel item);
        Task DeleteAsync(int id);

    }
}
