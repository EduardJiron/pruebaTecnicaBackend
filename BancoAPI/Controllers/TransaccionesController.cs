using BancoAPI.DTOs;
using BancoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionesController : ControllerBase
    {
        private readonly ITransaccionService _transaccionService;

        public TransaccionesController(ITransaccionService transaccionService)
        {
            _transaccionService = transaccionService;
        }

        [HttpPost("deposito")]
        public async Task<IActionResult> Depositar([FromBody] TransaccionDTO dto)
        {
            var exito = await _transaccionService.DepositarAsync(dto.NumeroCuenta, dto.Monto);
            return exito ? Ok() : BadRequest("Cuenta no encontrada");
        }

        [HttpPost("retiro")]
        public async Task<IActionResult> Retirar([FromBody] TransaccionDTO dto)
        {
            var exito = await _transaccionService.RetirarAsync(dto.NumeroCuenta, dto.Monto);
            return exito ? Ok() : BadRequest("Fondos insuficientes o cuenta no encontrada");
        }

        [HttpGet("historial")]
        public async Task<IActionResult> Historial([FromQuery] string numeroCuenta)
        {
            var historial = await _transaccionService.HistorialAsync(numeroCuenta);
            return Ok(historial);
        }
    }
}
