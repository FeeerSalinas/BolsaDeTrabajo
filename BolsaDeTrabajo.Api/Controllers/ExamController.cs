using BolsaDeTrabajo.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BolsaDeTrabajo.Commands.examenCommands;
using static BolsaDeTrabajo.Queries.examenQueries;
using System.Security.Claims;

namespace BolsaDeTrabajo.Api.Controllers
{
    public class ExamController : Controller
    {
        [ApiController]
        [Route("api/[controller]")]
        [Authorize]
        public class ExamenController : ControllerBase
        {
            private readonly IMediator _mediator;
            private readonly IAspiranteRepo _aspiranteRepo;

            public ExamenController(IMediator mediator, IAspiranteRepo aspiranteRepo)
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
            public async Task<IActionResult> Crear([FromBody] CrearExamenCommand command)
            {
                if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

                var creado = await _mediator.Send(command);
                return creado ? Ok("Examen creado") : BadRequest("No se pudo crear");
            }

            [HttpPut("editar")]
            public async Task<IActionResult> Editar([FromBody] EditarExamenCommand command)
            {
                if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

                var actualizado = await _mediator.Send(command);
                return actualizado ? Ok("Examen actualizado") : NotFound("No encontrado");
            }

            [HttpDelete("eliminar/{id}")]
            public async Task<IActionResult> Eliminar(int id)
            {
                var examen = await _mediator.Send(new ObtenerExamenPorIdQuery(id));
                if (examen is null || !await EsAspiranteDelUsuario(examen.IdAspirante)) return Forbid();

                var eliminado = await _mediator.Send(new EliminarExamenCommand(id));
                return eliminado ? Ok("Eliminado") : NotFound("No encontrado");
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> ObtenerPorId(int id)
            {
                var examen = await _mediator.Send(new ObtenerExamenPorIdQuery(id));
                if (examen is null || !await EsAspiranteDelUsuario(examen.IdAspirante)) return Forbid();

                return Ok(examen);
            }

            [HttpGet("todos")]
            public async Task<IActionResult> ObtenerTodos()
            {
                var examenes = await _mediator.Send(new ObtenerTodosExamenesQuery());
                return Ok(examenes);
            }

            [HttpGet("paginado")]
            public async Task<IActionResult> ObtenerPaginados([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
            {
                var examenes = await _mediator.Send(new ObtenerExamenesPaginadosQuery(page, pageSize));
                return Ok(examenes);
            }
        }
    }
}
