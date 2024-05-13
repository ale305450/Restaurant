using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Restaurant.Presistence
{
    public class RestaurantDbContextFactory : IDesignTimeDbContextFactory<RestaurantDbContext>
    {
        public RestaurantDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var bulider = new DbContextOptionsBuilder<RestaurantDbContext>();

            var connectionString = configuration.GetConnectionString("RestaurantConnectionString");

            bulider.UseSqlServer(connectionString);

            return new RestaurantDbContext(bulider.Options);
        }
    }
}
