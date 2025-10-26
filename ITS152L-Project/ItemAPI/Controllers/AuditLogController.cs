using ItemDataLibrary.Models;
using ITS152L_Project.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITS152L_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogService _service;

        public AuditLogController(IAuditLogService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<AuditLog>>> GetAllLogs()
        {
            return Ok(await _service.GetAllLogsAsync());
        }

        [HttpGet("recent/{count}")]
        public async Task<ActionResult<IEnumerable<AuditLog>>> GetRecentLogs(int count)
        {
            return Ok(await _service.GetRecentAsync(count));
        }

        [HttpGet("user/{userName}")]
        public async Task<ActionResult<IEnumerable<AuditLog>>> GetLogsByUser(string userName)
        {
            return Ok(await _service.GetByUserAsync(userName));
        }

        [HttpGet("entity/{entityType}/{entityId}")]
        public async Task<ActionResult<IEnumerable<AuditLog>>> GetLogsByEntity(
            string entityType, int entityId)
        {
            return Ok(await _service.GetByEntityAsync(entityType, entityId));
        }
    }
}
