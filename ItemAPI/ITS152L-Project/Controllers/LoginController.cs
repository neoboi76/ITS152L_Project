using ItemDataLibrary.Models;
using ITS152L_Project.Data;
using ITS152L_Project.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/*

Developed by: Dino Alfred T. Timbol

*/

//Log in controller
namespace ITS152L_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        //Depedency injection
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        //Returns an existing user from the database via a GET request
        public async Task<ActionResult<UserModel>> GetUserById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //Log's a user (i.e., verifies if credentials exist in the database)
        //via a POST request. If user does not exist, it will be added as a new
        //User to the database.
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

        //Reset's user password in the database via a POST request.
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
