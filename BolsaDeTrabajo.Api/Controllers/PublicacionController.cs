using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BolsaDeTrabajo.Commands.publicacionCommands;
using static BolsaDeTrabajo.Queries.publicacionQueries;
using System.Security.Claims;

namespace BolsaDeTrabajo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PublicacionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAspiranteRepo _aspiranteRepo;

        public PublicacionController(IMediator mediator, IAspiranteRepo aspiranteRepo)
        {
            _mediator = mediator;
            _aspiranteRepo = aspiranteRepo;
        }

        private int GetUserId() =>
            int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        private async Task<bool> EsAspiranteDelUsuario(int idAspirante)
        {
            var aspirante = await _aspiranteRepo.ObtenerPorIdAsync(idAspirante, CancellationToken.None);
            return aspirante?.IdUsuario == GetUserId();
        }

        [HttpPost("crear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Crear([FromBody] CrearPublicacionCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

            var creado = await _mediator.Send(command);
            return creado ? Ok("Publicación creada") : BadRequest("No se pudo crear");
        }

        [HttpPut("editar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Editar([FromBody] EditarPublicacionCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

            var actualizado = await _mediator.Send(command);
            return actualizado ? Ok("Publicación actualizada") : NotFound("No encontrado");
        }

        [HttpDelete("eliminar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Eliminar(int id)
        {
            var publicacion = await _mediator.Send(new ObtenerPublicacionPorIdQuery(id));
            if (publicacion == null) return NotFound("No encontrado");
            if (!await EsAspiranteDelUsuario(publicacion.IdAspirante)) return Forbid();

            var eliminado = await _mediator.Send(new EliminarPublicacionCommand(id));
            return eliminado ? Ok("Eliminado") : NotFound("No encontrado");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Publicacion), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var publicacion = await _mediator.Send(new ObtenerPublicacionPorIdQuery(id));
            if (publicacion == null) return NotFound("No encontrado");
            if (!await EsAspiranteDelUsuario(publicacion.IdAspirante)) return Forbid();

            return Ok(publicacion);
        }

        [HttpGet("todos")]
        [ProducesResponseType(typeof(List<Publicacion>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodos()
        {
            var publicaciones = await _mediator.Send(new ObtenerTodasPublicacionesQuery());
            return Ok(publicaciones);
        }

        [HttpGet("paginado")]
        [ProducesResponseType(typeof(List<Publicacion>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerPaginados([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var publicaciones = await _mediator.Send(new ObtenerPublicacionesPaginadasQuery(page, pageSize));
            return Ok(publicaciones);
        }
    }
}
