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

