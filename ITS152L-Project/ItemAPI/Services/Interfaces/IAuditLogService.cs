using ItemDataLibrary.Models;

namespace ITS152L_Project.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task LogActionAsync(string userName, string action, string entityType,
            int entityId, string details);
        Task<IEnumerable<AuditLog>> GetAllLogsAsync();
        Task<IEnumerable<AuditLog>> GetByEntityAsync(string entityType, int entityId);
        Task<IEnumerable<AuditLog>> GetByUserAsync(string userName);
        Task<IEnumerable<AuditLog>> GetRecentAsync(int count);
    }
}
