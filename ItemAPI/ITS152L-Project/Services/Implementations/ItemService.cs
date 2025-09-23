using ItemDataLibrary.Models;
using ITS152L_Project.Repositories.Implementations;
using ITS152L_Project.Repositories.Interfaces;
using ITS152L_Project.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
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

            if (entity?.Id == 0 || entity?.Id == null)
                return _repository.AddAsync(entity);

            return _repository.UpdateAsync(entity);

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

        public Task<ItemModel> UpdateAsync(ItemModel updatedItem)
        {
            if (updatedItem?.Id == 0 || updatedItem?.Id == null)
            {
                return _repository.AddAsync(updatedItem);
            }

            else
            {
                return _repository.UpdateAsync(updatedItem);
            }

        }
    }
}
