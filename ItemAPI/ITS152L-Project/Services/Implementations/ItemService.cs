using ItemDataLibrary.Models;
using ITS152L_Project.Repositories.Implementations;
using ITS152L_Project.Repositories.Interfaces;
using ITS152L_Project.Services.Interfaces;
using static Dapper.SqlMapper;

namespace ITS152L_Project.Services.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public Task<ItemModel> AddAsync(ItemModel entity)
        {
            return _repository.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<IEnumerable<ItemModel>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<ItemModel?> GetByIdAsync(int id)
        {

            if (id <= 0)
                throw new ArgumentException("Invalid ID");

            return _repository.GetByIdAsync(id);
        }

        public Task UpdateAsync(ItemModel entity)
        {
            return _repository.UpdateAsync(entity);
        }
    }
}
