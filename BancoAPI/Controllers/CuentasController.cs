using BancoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;

        public CuentasController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> CrearCuenta(int clienteId, decimal saldoInicial)
        {
            var cuenta = await _cuentaService.CrearCuentaAsync(clienteId, saldoInicial);
            return Ok(cuenta);
        }

        [HttpGet("saldo")]
        public async Task<IActionResult> ObtenerSaldo([FromQuery] string numeroCuenta)
        {
            var saldo = await _cuentaService.ConsultarSaldoAsync(numeroCuenta);
            return Ok(new { Saldo = saldo });
        }
    }
}
