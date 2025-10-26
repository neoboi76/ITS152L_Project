using ItemDataLibrary.Models;

namespace ITS152L_Project.Repositories.Interfaces
{
    public interface IAuditLogRepository : IRepository<AuditLog>
    {
        Task<IEnumerable<AuditLog>> GetByEntityAsync(string entityType, int entityId);
        Task<IEnumerable<AuditLog>> GetByUserAsync(string userName);
        Task<IEnumerable<AuditLog>> GetRecentAsync(int count);
    }
}
