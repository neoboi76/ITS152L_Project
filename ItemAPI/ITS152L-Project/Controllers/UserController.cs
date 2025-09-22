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

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            return Ok(await _service.GetAllAsync());
        }

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


    }
}
