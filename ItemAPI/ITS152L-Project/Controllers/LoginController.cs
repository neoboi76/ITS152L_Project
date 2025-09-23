using ItemDataLibrary.Models;
using ITS152L_Project.Data;
using ITS152L_Project.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITS152L_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        public async Task<ActionResult<UserModel>> GetUserById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost("log")]
        public async Task<ActionResult<UserLogin>> LogUser([FromBody] UserLogin realUser)
        {
            var user = await _service.LogAsync(realUser);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }

        [HttpPost("reset")]
        public async Task<ActionResult<UserLogin>> ResUserPass([FromBody] UserLogin existingUser)
        {
            var user = await _service.ResAsync(existingUser);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }

    }
}
