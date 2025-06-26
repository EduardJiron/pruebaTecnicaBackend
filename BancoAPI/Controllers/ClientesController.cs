using BancoAPI.DTOs;
using BancoAPI.Models;
using BancoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCliente([FromBody] ClienteDTO dto)
        {
            var cliente = new Cliente
            {
                Nombre = dto.Nombre,
                FechaNacimiento = dto.FechaNacimiento,
                Sexo = dto.Sexo,
                Ingresos = dto.Ingresos
            };
            var creado = await _clienteService.CrearClienteAsync(cliente);
            return Ok(creado);
        }
    }
}
