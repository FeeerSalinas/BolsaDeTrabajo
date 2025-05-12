using BolsaDeTrabajo.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BolsaDeTrabajo.Commands.cotactosCommands;
using System.Security.Claims;
using static BolsaDeTrabajo.Queries.contactoQueries;

namespace BolsaDeTrabajo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ContactoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private int GetUserId() =>
            int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        /// <summary>Crear un contacto</summary>
        [HttpPost("crear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Crear([FromBody] CrearContactoCommand command)
        {
            if (command.IdUsuario != GetUserId()) return Forbid();

            var creado = await _mediator.Send(command);
            return creado ? Ok("Contacto creado") : BadRequest("No se pudo crear");
        }

        /// <summary>Editar contacto</summary>
        [HttpPut("editar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Editar([FromBody] EditarContactoCommand command)
        {
            if (command.IdUsuario != GetUserId()) return Forbid();

            var actualizado = await _mediator.Send(command);
            return actualizado ? Ok("Contacto actualizado") : NotFound("No encontrado");
        }

        /// <summary>Eliminar contacto</summary>
        [HttpDelete("eliminar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Eliminar(int id)
        {
            if (id != GetUserId()) return Forbid();

            var eliminado = await _mediator.Send(new EliminarContactoCommand(id));
            return eliminado ? Ok("Eliminado") : NotFound("No encontrado");
        }

        /// <summary>Obtener contacto por ID</summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Contacto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            if (id != GetUserId()) return Forbid();

            var contacto = await _mediator.Send(new ObtenerContactoPorIdQuery(id));
            return contacto is null ? NotFound("No encontrado") : Ok(contacto);
        }

        /// <summary>Obtener todos los contactos (admin)</summary>
        [HttpGet("todos")]
        [ProducesResponseType(typeof(List<Contacto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodos()
        {
            var contactos = await _mediator.Send(new ObtenerTodosContactosQuery());
            return Ok(contactos);
        }

        /// <summary>Obtener contactos paginados (admin)</summary>
        [HttpGet("paginado")]
        [ProducesResponseType(typeof(List<Contacto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerPaginados([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var contactos = await _mediator.Send(new ObtenerContactosPaginadosQuery(page, pageSize));
            return Ok(contactos);
        }
    }
}
