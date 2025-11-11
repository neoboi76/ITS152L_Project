using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * Audit log model entity (table), 
 * representing the internal model representation of the audit logs
 **/

namespace ItemDataLibrary.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Action { get; set; } = null!; // "Added", "Updated", "Deleted"
        public string EntityType { get; set; } = null!; // "Item"
        public int EntityId { get; set; }
        public string Details { get; set; } = null!;
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
