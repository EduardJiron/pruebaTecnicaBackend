using BancoAPI.Data;
using BancoAPI.Models;
using BancoAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BancoAPI.Tests.Services
{
    public class CuentaServiceTests
    {
        private BancoDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<BancoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // DB única por test
                .Options;
            return new BancoDbContext(options);
        }

        [Fact]
        public async Task CrearCuentaAsync_CreaCuentaCorrectamente()
        {
            var context = GetInMemoryDbContext();

            // Crear cliente para la cuenta
            var cliente = new Cliente { Nombre = "Cliente Test", FechaNacimiento = DateTime.Parse("1990-01-01"), Sexo = "M", Ingresos = 1000 };
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();

            var service = new CuentaService(context);

            // Crear cuenta
            var cuenta = await service.CrearCuentaAsync(cliente.Id, 1000);

            Assert.NotNull(cuenta);
            Assert.Equal(cliente.Id, cuenta.ClienteId);
            Assert.Equal(1000, cuenta.Saldo);
        }

        [Fact]
        public async Task Depositar_Retirar_ActualizaSaldoCorrectamente()
        {
            var context = GetInMemoryDbContext();

            var cliente = new Cliente { Nombre = "Cliente Test", FechaNacimiento = DateTime.Parse("1990-01-01"), Sexo = "M", Ingresos = 1000 };
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();

            var service = new CuentaService(context);

            var cuenta = await service.CrearCuentaAsync(cliente.Id, 1000);

            // Depositar
            await service.DepositarAsync(cuenta.NumeroCuenta, 500);
            var saldoDespuesDeposito = await service.ConsultarSaldoAsync(cuenta.NumeroCuenta);
            Assert.Equal(1500, saldoDespuesDeposito);

            // Retirar
            await service.RetirarAsync(cuenta.NumeroCuenta, 200);
            var saldoDespuesRetiro = await service.ConsultarSaldoAsync(cuenta.NumeroCuenta);
            Assert.Equal(1300, saldoDespuesRetiro);
        }

        [Fact]
        public async Task AplicarInteres_SumaCorrectamenteAlSaldo()
        {
            var context = GetInMemoryDbContext();

            var cliente = new Cliente { Nombre = "Cliente Test", FechaNacimiento = DateTime.Parse("1990-01-01"), Sexo = "M", Ingresos = 1000 };
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();

            var service = new CuentaService(context);

            var cuenta = await service.CrearCuentaAsync(cliente.Id, 1000);

            // Supongamos tasa 5%
            decimal tasaInteres = 0.05m;

            await service.AplicarInteresAsync(cuenta.NumeroCuenta, tasaInteres);

            var saldoConInteres = await service.ConsultarSaldoAsync(cuenta.NumeroCuenta);

            Assert.Equal(1050, saldoConInteres);
        }

        [Fact]
        public async Task ConsultarSaldo_Y_ObtenerHistorialTransacciones()
        {
            var context = GetInMemoryDbContext();

            var cliente = new Cliente { Nombre = "Cliente Test", FechaNacimiento = DateTime.Parse("1990-01-01"), Sexo = "M", Ingresos = 1000 };
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();

            var service = new CuentaService(context);

            var cuenta = await service.CrearCuentaAsync(cliente.Id, 1000);

            await service.DepositarAsync(cuenta.NumeroCuenta, 200);
            await service.RetirarAsync(cuenta.NumeroCuenta, 100);

            var saldo = await service.ConsultarSaldoAsync(cuenta.NumeroCuenta);
            var historial = await service.ObtenerHistorialTransaccionesAsync(cuenta.NumeroCuenta);

            Assert.Equal(1100, saldo);
            Assert.NotNull(historial);
            Assert.Equal(3, historial.Count); // 1 creación + 2 transacciones
        }
    }
}
