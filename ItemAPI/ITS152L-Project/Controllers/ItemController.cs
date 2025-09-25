using ITS152L_Project.Data;
using ItemDataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITS152L_Project.Services.Interfaces;

/*

Developed by: Dino Alfred T. Timbol

*/

//Item REST controller

namespace ITS152L_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        //Depdendency Injection
        private readonly IItemService _service;

        public ItemController(IItemService service)
        {
            _service = service;
        }

        //Returns all items in the database via GET request
        [HttpGet("getAll")]
        public async Task<ActionResult<List<ItemModel>>> GetAllItems()
        {
            return Ok(await _service.GetAllAsync());
        }

        //Returns a specific item from the database via a GET request
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemModel>> GetItemById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }


        //Adds an item to the database via a POST request
        [HttpPost("add")]
        public async Task<ActionResult<ItemModel>> AddItem(ItemModel newItem)
        {
            if (newItem == null)
            {
                return BadRequest();
            }

            await _service.AddAsync(newItem);

            return CreatedAtAction(nameof(GetItemById), new { id = newItem.Id }, newItem);

        }


        //Modifies an item in the database via a PUT request
        [HttpPut("update/{id}")]
        public async  Task<IActionResult> UpdateItem(ItemModel updatedItem)
        {
            var item = await _service.UpdateAsync(updatedItem);
            if (item == null)
            {
                return NotFound();
            }

            return NoContent();

        }

        //Deletes an item from the database via a DELETE request
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }

        /*
        [HttpDelete]
        public async Task<IActionResult> DeleteAll(int id)
        {
            var allItems = _context.Items.ToList();
            if (allItems == null)
            {
                return NotFound();
            }

            _context.Items.RemoveRange(allItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

    } 

}