using ItemDataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*

Developed by: 

    Ken Aliling
    Carl Norbi Felonia
    Cedrick Miguel Kaneko
    Amar Jacob Pajarito
    Dino Alfred Timbol

*/

//Configures the connection between API and database, and sets up
//the models that will represent the tables to be created in the
//database. This class abstracts CRUD operations by having predefined
//methods and functionalities to manage the MySQL database without
//having to make use of actual SQL code

namespace ITS152L_Project.Data
{
    public class ItemApiContext : DbContext
    {

        //Sets up the context
        public ItemApiContext(DbContextOptions<ItemApiContext> options) : base(options) {}
    
        //Allows developers to manipulate and specify what the database should do.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserLogin>().HasNoKey();

        }

        //Adds models as tables in the database
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }


    }
}
