namespace BancoAPI.Services
{
    using BancoAPI.Models;
    public interface IClienteService
    {
        Task<Cliente> CrearClienteAsync(Cliente cliente);
    }
}
