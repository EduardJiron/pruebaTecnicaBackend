using BancoAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BancoAPI
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BancoDbContext>
    {
        public BancoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BancoDbContext>();
            optionsBuilder.UseSqlite("Data Source=banco.db");

            return new BancoDbContext(optionsBuilder.Options);
        }
    }
}
