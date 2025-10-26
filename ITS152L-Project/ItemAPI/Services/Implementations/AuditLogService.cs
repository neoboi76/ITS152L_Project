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

        public Task<IEnumerable<AuditLog>> GetAllLogsAsync() => _repository.GetAllAsync();
        public Task<IEnumerable<AuditLog>> GetByEntityAsync(string entityType, int entityId)
            => _repository.GetByEntityAsync(entityType, entityId);
        public Task<IEnumerable<AuditLog>> GetByUserAsync(string userName)
            => _repository.GetByUserAsync(userName);
        public Task<IEnumerable<AuditLog>> GetRecentAsync(int count)
            => _repository.GetRecentAsync(count);
    }
}
