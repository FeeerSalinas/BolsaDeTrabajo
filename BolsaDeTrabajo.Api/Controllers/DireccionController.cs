using BolsaDeTrabajo.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BolsaDeTrabajo.Commands.direccionCommands;
using static BolsaDeTrabajo.Queries.direccionQueries;
using System.Security.Claims;

namespace BolsaDeTrabajo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DireccionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DireccionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private int GetUserId() =>
            int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        /// <summary>Crear dirección</summary>
        [HttpPost("crear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Crear([FromBody] CrearDireccionCommand command)
        {
            if (command.IdUsuario != GetUserId()) return Forbid();

            var creado = await _mediator.Send(command);
            return creado ? Ok("Dirección creada") : BadRequest("No se pudo crear");
        }

        /// <summary>Editar dirección</summary>
        [HttpPut("editar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Editar([FromBody] EditarDireccionCommand command)
        {
            if (command.IdUsuario != GetUserId()) return Forbid();

            var actualizado = await _mediator.Send(command);
            return actualizado ? Ok("Dirección actualizada") : NotFound("No encontrada");
        }

        /// <summary>Eliminar dirección</summary>
        [HttpDelete("eliminar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Eliminar(int id)
        {
            if (id != GetUserId()) return Forbid();

            var eliminado = await _mediator.Send(new EliminarDireccionCommand(id));
            return eliminado ? Ok("Dirección eliminada") : NotFound("No encontrada");
        }

        /// <summary>Obtener dirección por ID</summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Direccion), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            if (id != GetUserId()) return Forbid();

            var direccion = await _mediator.Send(new ObtenerDireccionPorIdQuery(id));
            return direccion is null ? NotFound("No encontrada") : Ok(direccion);
        }

        /// <summary>Obtener todas las direcciones (admin)</summary>
        [HttpGet("todos")]
        [ProducesResponseType(typeof(List<Direccion>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodos()
        {
            var direcciones = await _mediator.Send(new ObtenerTodasDireccionesQuery());
            return Ok(direcciones);
        }

        /// <summary>Obtener direcciones paginadas (admin)</summary>
        [HttpGet("paginado")]
        [ProducesResponseType(typeof(List<Direccion>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerPaginado([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var direcciones = await _mediator.Send(new ObtenerDireccionesPaginadasQuery(page, pageSize));
            return Ok(direcciones);
        }
    }
}
