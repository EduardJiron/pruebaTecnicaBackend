namespace BancoAPI.Services
{
    using BancoAPI.Data;
    using BancoAPI.Models;
    using Microsoft.EntityFrameworkCore;

    public class CuentaService : ICuentaService
    {
        private readonly BancoDbContext _context;
        public CuentaService(BancoDbContext context) => _context = context;

        public async Task<CuentaBancaria> CrearCuentaAsync(int clienteId, decimal saldoInicial)
        {
            var cuenta = new CuentaBancaria
            {
                ClienteId = clienteId,
                NumeroCuenta = Guid.NewGuid().ToString(),
                Saldo = saldoInicial
            };
            _context.CuentasBancarias.Add(cuenta);
            await _context.SaveChangesAsync();
            return cuenta;
        }

        public async Task<decimal> ConsultarSaldoAsync(string numeroCuenta)
        {
            var cuenta = await _context.CuentasBancarias.FirstOrDefaultAsync(c => c.NumeroCuenta == numeroCuenta);
            return cuenta?.Saldo ?? 0;
        }
    }
}