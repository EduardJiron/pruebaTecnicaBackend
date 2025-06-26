using System.Collections.Generic;
using System.Threading.Tasks;
using BancoAPI.Models;

namespace BancoAPI.Services
{
    public interface ITransaccionService
    {
        Task<bool> DepositarAsync(string numeroCuenta, decimal monto);
        Task<bool> RetirarAsync(string numeroCuenta, decimal monto);
        Task<List<Transaccion>> HistorialAsync(string numeroCuenta);
    }
}
