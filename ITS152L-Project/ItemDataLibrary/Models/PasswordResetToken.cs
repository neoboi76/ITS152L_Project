using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItemDataLibrary.Models
{
    public class PasswordResetToken
    {
        public int Id { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string Token { get; set; } = null!;

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; } = null!;

        [Required]
        public DateTime Expiry { get; set; }

        [Required]
        public bool IsUsed { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UsedAt { get; set; }
        public bool IsValid()
        {
            return !IsUsed && DateTime.Now <= Expiry;
        }
        public void MarkAsUsed()
        {
            IsUsed = true;
            UsedAt = DateTime.Now;
            Expiry = DateTime.Now; 
        }
    }
}