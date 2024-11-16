using expo_tec_upgrade_b.Connection;
using expo_tec_upgrade_b.Models;
using expo_tec_upgrade_b.Services;
using Microsoft.AspNetCore.Mvc;

namespace expo_tec_upgrade_b.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly ConnectionDB connection;
        private readonly ClienteService _service;

        public ClienteController(ClienteService service, ConnectionDB connection)
        {
            this._service = service;
            this.connection = connection;
        }


        [HttpGet("ObtenerClientes")]
        public async Task<ActionResult<List<Cliente>>> GetAllClientes()
        {
            var operarios = await _service.GetAllClientes();

            if (operarios == null || operarios.Count == 0)
            {
                return NoContent();
            }

            return Ok(operarios);
        }

        [HttpPost("AgregarCliente")]
        public async Task<ActionResult> PostCliente([FromBody] Cliente nuevoCliente)
        {
            if (nuevoCliente == null)
            {
                return BadRequest("Cliente no puede ser nulo");
            }

            var success = await _service.PostCliente(nuevoCliente);

            if (success)
            {
                return CreatedAtAction(nameof(GetAllClientes), new { id = nuevoCliente.Id }, nuevoCliente);
            }
            else
            {
                return StatusCode(500, "Error al crear el cliente");
            }
        }
    }
}
