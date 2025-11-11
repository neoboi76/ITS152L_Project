/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * Interface for the IAuditLogRepository. Promotes dependency injection
 * and loosely coupled relationships
 **/

using ItemDataLibrary.Models;

namespace ITS152L_Project.Repositories.Interfaces
{
    public interface IAuditLogRepository : IRepository<AuditLog> //Extends Generic Interface Repository (uses generic CRUD repository operations)
    {
        //Has custom methods
        Task<IEnumerable<AuditLog>> GetByEntityAsync(string entityType, int entityId);
        Task<IEnumerable<AuditLog>> GetByUserAsync(string userName);
        Task<IEnumerable<AuditLog>> GetRecentAsync(int count);
    }
}
