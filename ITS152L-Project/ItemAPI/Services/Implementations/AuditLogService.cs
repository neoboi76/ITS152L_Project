/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * AuditLogService class. Deals with audit-log related
 * operations
 **/

using ItemDataLibrary.Models;
using ITS152L_Project.Repositories.Interfaces;
using ITS152L_Project.Services.Interfaces;

namespace ITS152L_Project.Services.Implementations
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _repository;

        public AuditLogService(IAuditLogRepository repository)
        {
            _repository = repository;
        }

        //Logs an action done by or to an entity (user or item)
        public async Task LogActionAsync(string userName, string action,
            string entityType, int entityId, string details)
        {
            var log = new AuditLog
            {
                UserName = userName,
                Action = action,
                EntityType = entityType,
                EntityId = entityId,
                Details = details,
                Timestamp = DateTime.Now
            };

            await _repository.AddAsync(log);
        }

        //Retrieves all audit logs
        public Task<IEnumerable<AuditLog>> GetAllLogsAsync() => _repository.GetAllAsync();

        //Retrieve audit logs for a given entity
        public Task<IEnumerable<AuditLog>> GetByEntityAsync(string entityType, int entityId)
            => _repository.GetByEntityAsync(entityType, entityId);

        //Retrieve audit logs of a user
        public Task<IEnumerable<AuditLog>> GetByUserAsync(string userName)
            => _repository.GetByUserAsync(userName);

        //Retrieve most recent audit logs
        public Task<IEnumerable<AuditLog>> GetRecentAsync(int count)
            => _repository.GetRecentAsync(count);
    }
}
