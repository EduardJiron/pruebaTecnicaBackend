using BancoAPI.Data;
using BancoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAPI.Services
{
    public class TransaccionService : ITransaccionService
    {
        private readonly BancoDbContext _context;

        public TransaccionService(BancoDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DepositarAsync(string numeroCuenta, decimal monto)
        {
            var cuenta = await _context.CuentasBancarias
                .FirstOrDefaultAsync(c => c.NumeroCuenta == numeroCuenta);

            if (cuenta == null) return false;

            cuenta.Saldo += monto;

            var transaccion = new Transaccion
            {
                Tipo = "Depósito",
                Monto = monto,
                Fecha = DateTime.Now,
                SaldoDespues = cuenta.Saldo,
                CuentaBancariaId = cuenta.Id
            };

            _context.Transacciones.Add(transaccion);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RetirarAsync(string numeroCuenta, decimal monto)
        {
            var cuenta = await _context.CuentasBancarias
                .FirstOrDefaultAsync(c => c.NumeroCuenta == numeroCuenta);

            if (cuenta == null || cuenta.Saldo < monto) return false;

            cuenta.Saldo -= monto;

            var transaccion = new Transaccion
            {
                Tipo = "Retiro",
                Monto = monto,
                Fecha = DateTime.Now,
                SaldoDespues = cuenta.Saldo,
                CuentaBancariaId = cuenta.Id
            };

            _context.Transacciones.Add(transaccion);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Transaccion>> HistorialAsync(string numeroCuenta)
        {
            var cuenta = await _context.CuentasBancarias
                .FirstOrDefaultAsync(c => c.NumeroCuenta == numeroCuenta);

            if (cuenta == null) return new List<Transaccion>();

            return await _context.Transacciones
                .Where(t => t.CuentaBancariaId == cuenta.Id)
                .OrderByDescending(t => t.Fecha)
                .ToListAsync();
        }
    }
}
