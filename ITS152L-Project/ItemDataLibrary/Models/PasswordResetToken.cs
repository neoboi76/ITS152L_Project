using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItemDataLibrary.Models
{
    /// <summary>
    /// Password reset token entity for secure password reset functionality
    /// Developed by: Ken Aliling, Carl Norbi Felonia, Cedrick Miguel Kaneko, 
    ///               Amar Jacob Pajarito, Dino Alfred Timbol
    /// </summary>
    [Table("password_reset_tokens")]
    public class PasswordResetToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        /// <summary>
        /// Checks if the token is valid (not expired and not used)
        /// </summary>
        public bool IsValid()
        {
            return !IsUsed && DateTime.Now <= Expiry;
        }

        /// <summary>
        /// Marks the token as used
        /// </summary>
        public void MarkAsUsed()
        {
            IsUsed = true;
            UsedAt = DateTime.Now;
            Expiry = DateTime.Now; // Immediately expire
        }
    }
}