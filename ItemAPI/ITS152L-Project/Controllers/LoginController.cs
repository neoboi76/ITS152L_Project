using ItemDataLibrary.Models;
using ITS152L_Project.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITS152L_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ItemAPIContext _context;

        public async Task<ActionResult<UserModel>> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        public LoginController(ItemAPIContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<UserLogin>> LogUser(UserLogin realUser)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Password == realUser.Password);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }

    }
}
