/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * Database context for the Teleoplex Inventory System
 **/


using ItemDataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ITS152L_Project.Data
{

    public class ItemApiContext : DbContext
    {
        public ItemApiContext(DbContextOptions<ItemApiContext> options) : base(options) { }


        //Builds context
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PasswordResetToken>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PasswordResetToken>()
                .HasIndex(t => t.Token);

            modelBuilder.Entity<PasswordResetToken>()
                .HasIndex(t => t.UserId);

            modelBuilder.Entity<PasswordResetToken>()
                .HasIndex(t => new { t.Token, t.UserId, t.IsUsed, t.Expiry });
        }

        //Sets model classes as database tables
        public DbSet<ItemModel> Items { get; set; } = null!;
        public DbSet<UserModel> Users { get; set; } = null!;
        public DbSet<AuditLog> AuditLogs { get; set; } = null!;
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; } = null!;
    }
}