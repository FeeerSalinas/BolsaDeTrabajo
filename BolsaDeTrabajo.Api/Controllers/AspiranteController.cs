using MediatR;
using Microsoft.AspNetCore.Mvc;
using static BolsaDeTrabajo.Commands.aspiranteCommands;
using static BolsaDeTrabajo.Queries.aspiranteQueries;

namespace BolsaDeTrabajo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AspiranteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AspiranteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] CrearAspiranteCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(ObtenerPorId), new { id }, new { id });
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarAspiranteCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _mediator.Send(new EliminarAspiranteCommand(id));
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var aspirante = await _mediator.Send(new ObtenerAspirantePorIdQuery(id));
            if (aspirante == null) return NotFound();
            return Ok(aspirante);
        }

        [HttpGet("todos")] 
        public async Task<IActionResult> ObtenerTodos()
        {
            var lista = await _mediator.Send(new ObtenerAspirantesQuery());
            return Ok(lista);
        }

        [HttpGet("paginado")]
        public async Task<IActionResult> ObtenerPaginado([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            var resultado = await _mediator.Send(new ObtenerAspirantesPaginadosQuery(page, size));
            return Ok(resultado);
        }

        [HttpGet("filtro-puesto/{puestoBusca}")]
        public async Task<IActionResult> ObtenerAspirantePorPuesto([FromRoute] string puestoBusca)
        {
            var resultado = await _mediator.Send(new ObtenersAspirantesPorPuesto(puestoBusca));
            return Ok(resultado);
        }
    }
}
