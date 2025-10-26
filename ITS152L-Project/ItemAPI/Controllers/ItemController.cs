using ItemDataLibrary.Models;
using ITS152L_Project.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITS152L_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _service;
        private readonly IAuditLogService _auditService;

        public ItemController(IItemService service, IAuditLogService auditService)
        {
            _service = service;
            _auditService = auditService;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ItemModel>> AddItem([FromBody] ItemModel newItem,
            [FromQuery] string userName)
        {
            if (newItem == null)
            {
                return BadRequest();
            }

            await _service.AddAsync(newItem);

            // Log the action
            await _auditService.LogActionAsync(
                userName,
                "Added",
                "Item",
                newItem.Id,
                $"Added {newItem.Quantity} units of {newItem.Name} (Code: {newItem.Code})"
            );

            return CreatedAtAction(nameof(GetItemById), new { id = newItem.Id }, newItem);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateItem([FromBody] ItemModel updatedItem,
            [FromQuery] string userName)
        {
            var existingItem = await _service.GetByIdAsync(updatedItem.Id);
            if (existingItem == null)
            {
                return NotFound();
            }

            await _service.UpdateAsync(updatedItem);

            // Log the changes
            var changes = new List<string>();
            if (existingItem.Quantity != updatedItem.Quantity)
                changes.Add($"Quantity: {existingItem.Quantity} → {updatedItem.Quantity}");
            if (existingItem.UnitPrice != updatedItem.UnitPrice)
                changes.Add($"Price: {existingItem.UnitPrice} → {updatedItem.UnitPrice}");
            if (existingItem.Name != updatedItem.Name)
                changes.Add($"Name: {existingItem.Name} → {updatedItem.Name}");

            await _auditService.LogActionAsync(
                userName,
                "Updated",
                "Item",
                updatedItem.Id,
                $"Updated {updatedItem.Name}: {string.Join(", ", changes)}"
            );

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id, [FromQuery] string userName)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);

            await _auditService.LogActionAsync(
                userName,
                "Deleted",
                "Item",
                id,
                $"Deleted {item.Name} (Code: {item.Code})"
            );

            return NoContent();
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<ItemModel>>> GetAllItems()
        {
            return Ok(await _service.GetAllAsync());
        }

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
    }
}