namespace BancoAPI.Services
{
    using BancoAPI.Models;
    public interface ICuentaService
    {
        Task<CuentaBancaria> CrearCuentaAsync(int clienteId, decimal saldoInicial);
        Task<decimal> ConsultarSaldoAsync(string numeroCuenta);
    }
}
