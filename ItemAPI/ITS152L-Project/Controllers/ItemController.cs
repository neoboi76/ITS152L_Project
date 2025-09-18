using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ITS152L_Project.Models;
using Microsoft.AspNetCore.Authorization;

namespace ITS152L_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        static private List<Item> items = new List<Item>
        {
            new Item
            {
                Id = 1,
                Name = "Book",
                Code = 1001,
                Brand = "Penguin",
                UnitPrice = 10.5
            },

            new Item
            {
                Id = 2,
                Name = "Soap",
                Code = 1002,
                Brand = "Safegaurd",
                UnitPrice = 12.5
            },

            new Item
            {
                Id = 3,
                Name = "Shampoo",
                Code = 1003,
                Brand = "Clear",
                UnitPrice = 8.5
            },

            new Item
            {
                Id = 4,
                Name = "Condom",
                Code = 1004,
                Brand = "Durex",
                UnitPrice = 6.5
            },

            new Item
            {
                Id = 5,
                Name = "Mouse",
                Code = 1005,
                Brand="Logitech",
                UnitPrice = 20.5
            },

        };

        [HttpGet]
        public ActionResult<List<Item>> GetAllItems()
        {
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItemById(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public ActionResult<Item> AddItem(Item newItem)
        {
            if (newItem == null)
            {
                return BadRequest();
            }

            items.Add(newItem);

            return CreatedAtAction(nameof(GetItemById), new { id = newItem.Id }, newItem);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, Item updatedItem)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            item.Id = updatedItem.Id;
            item.Name = updatedItem.Name;
            item.Code = updatedItem.Code;
            item.Brand = updatedItem.Brand;
            item.UnitPrice = updatedItem.UnitPrice;

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            items.Remove(item);

            return NoContent();
        }


    }
}