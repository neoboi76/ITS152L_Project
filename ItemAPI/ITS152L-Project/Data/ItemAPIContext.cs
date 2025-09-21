using ItemDataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS152L_Project.Data
{
    public class ItemAPIContext : DbContext
    {
        public ItemAPIContext(DbContextOptions<ItemAPIContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserLogin>().HasNoKey();

        }

        public DbSet<ItemModel> Items { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserLogin>  UserLogin { get; set; }

    }
}
