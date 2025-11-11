/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * UserController class. Deals with user related
 * http requeests
 **/


using ITS152L_Project.Data;
using ItemDataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITS152L_Project.Services.Interfaces;

namespace ITS152L_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ItemApiContext _context;

        public UserController(IUserService service, ItemApiContext context)
        {
            _service = service;
            _context = context;
        }

        //Retrieves all registered users
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            return Ok(await _service.GetAllAsync());
        }

        //Retrieves a particular registered user
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //Verifies if email exists in the database and is tied to a registered user
        [HttpGet("check-email/{email}")]
        public async Task<ActionResult> CheckEmailExists(string email)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == email);

            if (user == null)
            {
                return NotFound();
            }
            return Ok();
        }

        //Registers a user
        [HttpPost]
        public async Task<ActionResult<UserModel>> AddUser([FromBody] UserModel newUser)
        {
            if (newUser == null)
            {
                return BadRequest();
            }

            await _service.AddAsync(newUser);

            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        //Updates user role (from user to admin, done by the admin)
        [HttpPut("{id}/role")]
        public async Task<IActionResult> UpdateUserRole(int id, [FromBody] UserModel user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var existingUser = await _service.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Role = user.Role;
            await _service.UpdateAsync(existingUser);

            return NoContent();
        }

        //Deletes a registered user
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}