using Microsoft.EntityFrameworkCore;
using BancoAPI.Models;

namespace BancoAPI.Data
{
    public class BancoDbContext : DbContext
    {
        public BancoDbContext(DbContextOptions<BancoDbContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<CuentaBancaria> CuentasBancarias => Set<CuentaBancaria>();
        public DbSet<Transaccion> Transacciones => Set<Transaccion>();
    }
}
