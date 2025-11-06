using ItemDataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ITS152L_Project.Data
{
    /// <summary>
    /// Database context for the Teleoplex Inventory System
    /// Developed by: Ken Aliling, Carl Norbi Felonia, Cedrick Miguel Kaneko,
    ///               Amar Jacob Pajarito, Dino Alfred Timbol
    /// </summary>
    public class ItemApiContext : DbContext
    {
        public ItemApiContext(DbContextOptions<ItemApiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // UserLogin has no key
            modelBuilder.Entity<UserLogin>().HasNoKey();

            // Configure PasswordResetToken relationships
            modelBuilder.Entity<PasswordResetToken>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Add index on Token for faster lookups
            modelBuilder.Entity<PasswordResetToken>()
                .HasIndex(t => t.Token);

            // Add index on UserId for faster user token queries
            modelBuilder.Entity<PasswordResetToken>()
                .HasIndex(t => t.UserId);

            // Add composite index for token validation queries
            modelBuilder.Entity<PasswordResetToken>()
                .HasIndex(t => new { t.Token, t.UserId, t.IsUsed, t.Expiry });
        }

        public DbSet<ItemModel> Items { get; set; } = null!;
        public DbSet<UserModel> Users { get; set; } = null!;
        public DbSet<AuditLog> AuditLogs { get; set; } = null!;
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; } = null!;
    }
}