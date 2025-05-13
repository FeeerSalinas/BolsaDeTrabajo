using BolsaDeTrabajo.Commands;
using BolsaDeTrabajo.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BolsaDeTrabajo.Queries.idiomaQueries;
using System.Security.Claims;

namespace BolsaDeTrabajo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class IdiomaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAspiranteRepo _aspiranteRepo;

        public IdiomaController(IMediator mediator, IAspiranteRepo aspiranteRepo)
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
        public async Task<IActionResult> Crear([FromBody] CrearIdiomaCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

            var creado = await _mediator.Send(command);
            return creado ? Ok("Idioma creado") : BadRequest("No se pudo crear");
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarIdiomaCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

            var actualizado = await _mediator.Send(command);
            return actualizado ? Ok("Idioma actualizado") : NotFound("No encontrado");
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var idioma = await _mediator.Send(new ObtenerIdiomaPorIdQuery(id));
            if (idioma == null || !await EsAspiranteDelUsuario(idioma.IdAspirante)) return Forbid();

            var eliminado = await _mediator.Send(new EliminarIdiomaCommand(id));
            return eliminado ? Ok("Eliminado") : NotFound("No encontrado");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var idioma = await _mediator.Send(new ObtenerIdiomaPorIdQuery(id));
            if (idioma == null || !await EsAspiranteDelUsuario(idioma.IdAspirante)) return Forbid();

            return Ok(idioma);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            var idiomas = await _mediator.Send(new ObtenerTodosIdiomasQuery());
            return Ok(idiomas);
        }

        [HttpGet("paginado")]
        public async Task<IActionResult> ObtenerPaginado([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var idiomas = await _mediator.Send(new ObtenerIdiomasPaginadosQuery(page, pageSize));
            return Ok(idiomas);
        }
    }
}
