namespace BancoAPI.Services
{
    using BancoAPI.Data;
    using BancoAPI.Models;
    using Microsoft.EntityFrameworkCore;

    public class ClienteService : IClienteService
    {
        private readonly BancoDbContext _context;
        public ClienteService(BancoDbContext context) => _context = context;

        public async Task<Cliente> CrearClienteAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
