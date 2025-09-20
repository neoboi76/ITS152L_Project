using ItemDataLibrary.Data;
using ItemDataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITS152L_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly ItemAPIContext _context;

        public ItemController(ItemAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemModel>>> GetAllItems()
        {
            return Ok(await _context.Items.ToListAsync());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemModel>> GetItemById(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ItemModel>> AddItem(ItemModel newItem)
        {
            if (newItem == null)
            {
                return BadRequest();
            }

            _context.Items.Add(newItem);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemById), new { id = newItem.Id }, newItem);

        }

        [HttpPut("{id}")]
        public async  Task<IActionResult> UpdateItem(int id, ItemModel updatedItem)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Id = updatedItem.Id;
            item.Name = updatedItem.Name;
            item.Code = updatedItem.Code;
            item.Brand = updatedItem.Brand;
            item.UnitPrice = updatedItem.UnitPrice;
            item.Quantity = updatedItem.Quantity;

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

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
        }

    } 

}