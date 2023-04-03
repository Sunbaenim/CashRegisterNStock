using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CashRegisterNStock.DAL
{
    public class CrnsDbContextFactory : IDesignTimeDbContextFactory<CrnsDbContext>
    {
        public CrnsDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CashRegisterNStock.API"))
            .AddJsonFile("appsettings.json")
            .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CrnsDbContext>();
            optionsBuilder.UseSqlServer(ConfigurationExtensions.GetConnectionString(configuration, "CrnsDatabase"));
            return new CrnsDbContext(optionsBuilder.Options);
        }
    }
}
