using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BolsaDeTrabajo.Commands.habilidadCommands;
using static BolsaDeTrabajo.Queries.habilidadQueries;
using System.Security.Claims;

namespace BolsaDeTrabajo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class HabilidadController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAspiranteRepo _aspiranteRepo;

        public HabilidadController(IMediator mediator, IAspiranteRepo aspiranteRepo)
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
        public async Task<IActionResult> Crear([FromBody] CrearHabilidadCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

            var creado = await _mediator.Send(command);
            return creado ? Ok("Habilidad creada") : BadRequest("No se pudo crear");
        }

        [HttpPut("editar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Editar([FromBody] EditarHabilidadCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

            var actualizado = await _mediator.Send(command);
            return actualizado ? Ok("Habilidad actualizada") : NotFound("No encontrada");
        }

        [HttpDelete("eliminar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Eliminar(int id)
        {
            // Necesitamos obtener la habilidad para verificar a qué aspirante pertenece
            var habilidad = await _mediator.Send(new ObtenerHabilidadPorIdQuery(id));
            if (habilidad == null || !await EsAspiranteDelUsuario(habilidad.IdAspirante)) return Forbid();

            var eliminado = await _mediator.Send(new EliminarHabilidadCommand(id));
            return eliminado ? Ok("Eliminado") : NotFound("No encontrada");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Habilidad), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var habilidad = await _mediator.Send(new ObtenerHabilidadPorIdQuery(id));
            if (habilidad == null || !await EsAspiranteDelUsuario(habilidad.IdAspirante)) return Forbid();

            return Ok(habilidad);
        }

        [HttpGet("todos")]
        [ProducesResponseType(typeof(List<Habilidad>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodos()
        {
            var habilidades = await _mediator.Send(new ObtenerTodasHabilidadesQuery());
            return Ok(habilidades);
        }

        [HttpGet("paginado")]
        [ProducesResponseType(typeof(List<Habilidad>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerPaginados([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var habilidades = await _mediator.Send(new ObtenerHabilidadesPaginadasQuery(page, pageSize));
            return Ok(habilidades);
        }
    }
}
