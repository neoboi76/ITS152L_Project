using ITS152L_Project.Data;
using ItemDataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITS152L_Project.Services.Interfaces;

/*

Developed by: Dino Alfred T. Timbol

*/


//User controller
namespace ITS152L_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        //Dependency injection
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        //Gets all users from the database via a GET request
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            return Ok(await _service.GetAllAsync());
        }

        //Gets a particular user from the database via a GET request
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


        //Adds a user to the database via a POST request
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

        //Deletes an user from the database via a DELETE request
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }


    }
}
