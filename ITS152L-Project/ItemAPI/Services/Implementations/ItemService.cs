using ItemDataLibrary.Models;
using ITS152L_Project.Repositories.Implementations;
using ITS152L_Project.Repositories.Interfaces;
using ITS152L_Project.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using static Dapper.SqlMapper;

/*

Developed by: Dino Alfred T. Timbol

*/

//Item service class. Handles business logic and communicates
//with the controllers and repositories associated with items.

namespace ITS152L_Project.Services.Implementations
{
    public class ItemService : IItemService
    {

        //Dependency Injection
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }


        //Adds an item to the repository
        public Task<ItemModel> AddAsync(ItemModel entity)
        {

            if (entity?.Id == 0 || entity?.Id == null)
                return _repository.AddAsync(entity);

            return _repository.UpdateAsync(entity);

        }

        //Deletes an item from the repository
        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        //Get all items from the repository
        public Task<IEnumerable<ItemModel>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        //Get a specific item from the repository
        public Task<ItemModel?> GetByIdAsync(int id)
        {

            if (id <= 0)
                throw new ArgumentException("Invalid ID");

            return _repository.GetByIdAsync(id);
        }

        //Updates item information via the repository
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
