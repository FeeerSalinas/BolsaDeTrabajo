using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BolsaDeTrabajo.Commands.experienciaCommands;
using static BolsaDeTrabajo.Queries.experienciaQueries;
using System.Security.Claims;

namespace BolsaDeTrabajo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ExperienciaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAspiranteRepo _aspiranteRepo;

        public ExperienciaController(IMediator mediator, IAspiranteRepo aspiranteRepo)
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
        public async Task<IActionResult> Crear([FromBody] CrearExperienciaCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

            var creado = await _mediator.Send(command);
            return creado ? Ok("Experiencia creada") : BadRequest("No se pudo crear");
        }

        [HttpPut("editar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Editar([FromBody] EditarExperienciaCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

            var actualizado = await _mediator.Send(command);
            return actualizado ? Ok("Experiencia actualizada") : NotFound("No encontrada");
        }

        [HttpDelete("eliminar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Eliminar(int id)
        {
            var experiencia = await _mediator.Send(new ObtenerExperienciaPorIdQuery(id));
            if (experiencia == null || !await EsAspiranteDelUsuario(experiencia.IdAspirante)) return Forbid();

            var eliminado = await _mediator.Send(new EliminarExperienciaCommand(id));
            return eliminado ? Ok("Eliminado") : NotFound("No encontrado");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ExperienciaLaboral), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var experiencia = await _mediator.Send(new ObtenerExperienciaPorIdQuery(id));
            if (experiencia == null) return NotFound("No encontrada");

            if (!await EsAspiranteDelUsuario(experiencia.IdAspirante)) return Forbid();

            return Ok(experiencia);
        }

        [HttpGet("todos")]
        [ProducesResponseType(typeof(List<ExperienciaLaboral>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodos()
        {
            var lista = await _mediator.Send(new ObtenerTodasExperienciasQuery());
            return Ok(lista);
        }

        [HttpGet("paginado")]
        [ProducesResponseType(typeof(List<ExperienciaLaboral>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerPaginados([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var lista = await _mediator.Send(new ObtenerExperienciasPaginadasQuery(page, pageSize));
            return Ok(lista);
        }
    }
}
