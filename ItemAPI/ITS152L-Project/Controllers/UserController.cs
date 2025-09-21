using ITS152L_Project.Data;
using ItemDataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITS152L_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ItemAPIContext _context;

        public UserController(ItemAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> AddUser(UserModel newUser)
        {
            if (newUser == null)
            {
                return BadRequest();
            }

            _context.Users.Add(newUser);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserModel updatedUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Id = updatedUser.Id;
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.UserName = updatedUser.UserName;
            user.Password = updatedUser.Password;

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAll(int id)
        {
            var allUsers = _context.Users.ToList();
            if (allUsers == null)
            {
                return NotFound();
            }

            _context.Users.RemoveRange(allUsers);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
