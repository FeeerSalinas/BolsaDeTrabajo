using BolsaDeTrabajo.Commands;
using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BolsaDeTrabajo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EventoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAspiranteRepo _aspiranteRepo;

        public EventoController(IMediator mediator, IAspiranteRepo aspiranteRepo)
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
        public async Task<IActionResult> Crear([FromBody] eventosCommands.CrearEventoCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

            var creado = await _mediator.Send(command);
            return creado ? Ok("Evento creado") : BadRequest("No se pudo crear");
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] eventosCommands.EditarEventoCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

            var actualizado = await _mediator.Send(command);
            return actualizado ? Ok("Evento actualizado") : NotFound("No encontrado");
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var evento = await _mediator.Send(new eventosQueries.ObtenerEventoPorIdQuery(id));
            if (evento == null || !await EsAspiranteDelUsuario(evento.IdAspirante)) return Forbid();

            var eliminado = await _mediator.Send(new eventosCommands.EliminarEventoCommand(id));
            return eliminado ? Ok("Eliminado") : NotFound("No encontrado");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var evento = await _mediator.Send(new eventosQueries.ObtenerEventoPorIdQuery(id));
            if (evento == null || !await EsAspiranteDelUsuario(evento.IdAspirante)) return Forbid();

            return Ok(evento);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            var eventos = await _mediator.Send(new eventosQueries.ObtenerTodosEventosQuery());
            return Ok(eventos);
        }

        [HttpGet("paginado")]
        public async Task<IActionResult> ObtenerPaginados([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var eventos = await _mediator.Send(new eventosQueries.ObtenerEventosPaginadosQuery(page, pageSize));
            return Ok(eventos);
        }
    }
}
