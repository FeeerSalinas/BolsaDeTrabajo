using BolsaDeTrabajo.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BolsaDeTrabajo.Commands.formacionCommands;
using static BolsaDeTrabajo.Queries.formacionQueries;
using System.Security.Claims;

namespace BolsaDeTrabajo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FormacionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAspiranteRepo _aspiranteRepo;

        public FormacionController(IMediator mediator, IAspiranteRepo aspiranteRepo)
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
        public async Task<IActionResult> Crear([FromBody] CrearFormacionCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();
            var creado = await _mediator.Send(command);
            return creado ? Ok("Formación creada") : BadRequest("No se pudo crear");
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarFormacionCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();
            var actualizado = await _mediator.Send(command);
            return actualizado ? Ok("Formación actualizada") : NotFound("No encontrada");
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var formacion = await _mediator.Send(new ObtenerFormacionPorIdQuery(id));
            if (formacion is null || !await EsAspiranteDelUsuario(formacion.IdAspirante)) return Forbid();

            var eliminado = await _mediator.Send(new EliminarFormacionCommand(id));
            return eliminado ? Ok("Eliminada") : NotFound("No encontrada");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var formacion = await _mediator.Send(new ObtenerFormacionPorIdQuery(id));
            if (formacion is null || !await EsAspiranteDelUsuario(formacion.IdAspirante)) return Forbid();

            return Ok(formacion);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            var formaciones = await _mediator.Send(new ObtenerTodasFormacionesQuery());
            return Ok(formaciones);
        }

        [HttpGet("paginado")]
        public async Task<IActionResult> ObtenerPaginados([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var formaciones = await _mediator.Send(new ObtenerFormacionesPaginadasQuery(page, pageSize));
            return Ok(formaciones);
        }
    }
}
