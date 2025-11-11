/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * Database context factory for the Teleoplex Inventory System
 **/

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ITS152L_Project.Data
{
    public class ItemApiContextFactory : IDesignTimeDbContextFactory<ItemApiContext>
    {
        public ItemApiContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<ItemApiContext>(optional: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ItemApiContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlDb"));

            return new ItemApiContext(optionsBuilder.Options);
        }
    }
}

