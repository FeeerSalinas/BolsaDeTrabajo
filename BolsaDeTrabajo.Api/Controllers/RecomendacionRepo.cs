using BolsaDeTrabajo.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BolsaDeTrabajo.Commands.recomendacionCommands;
using static BolsaDeTrabajo.Queries.recomendacionQueries;
using System.Security.Claims;

namespace BolsaDeTrabajo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RecomendacionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAspiranteRepo _aspiranteRepo;

        public RecomendacionController(IMediator mediator, IAspiranteRepo aspiranteRepo)
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
        public async Task<IActionResult> Crear([FromBody] CrearRecomendacionCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

            var creado = await _mediator.Send(command);
            return creado ? Ok("Recomendación creada") : BadRequest("No se pudo crear");
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarRecomendacionCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

            var actualizado = await _mediator.Send(command);
            return actualizado ? Ok("Recomendación actualizada") : NotFound("No encontrado");
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var recomendacion = await _mediator.Send(new ObtenerRecomendacionPorIdQuery(id));
            if (recomendacion is null) return NotFound("No encontrado");

            if (!await EsAspiranteDelUsuario(recomendacion.IdAspirante)) return Forbid();

            var eliminado = await _mediator.Send(new EliminarRecomendacionCommand(id));
            return eliminado ? Ok("Eliminado") : NotFound("No encontrado");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var recomendacion = await _mediator.Send(new ObtenerRecomendacionPorIdQuery(id));
            if (recomendacion is null) return NotFound("No encontrado");

            if (!await EsAspiranteDelUsuario(recomendacion.IdAspirante)) return Forbid();

            return Ok(recomendacion);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            var recomendaciones = await _mediator.Send(new ObtenerTodasRecomendacionesQuery());
            return Ok(recomendaciones);
        }

        [HttpGet("paginado")]
        public async Task<IActionResult> ObtenerPaginado([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var recomendaciones = await _mediator.Send(new ObtenerRecomendacionesPaginadasQuery(page, pageSize));
            return Ok(recomendaciones);
        }
    }
}
