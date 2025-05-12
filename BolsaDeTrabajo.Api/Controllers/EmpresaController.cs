using MediatR;
using Microsoft.AspNetCore.Mvc;
using static BolsaDeTrabajo.Commands.EmpresaCommands;
using static BolsaDeTrabajo.Queries.EmpresaQueries;

namespace BolsaDeTrabajo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmpresaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] CrearEmpresaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(ObtenerPorId), new { id }, new { id });
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarEmpresaCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _mediator.Send(new EliminarEmpresaCommand(id));
            return result ? Ok() : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var empresa = await _mediator.Send(new ObtenerEmpresaPorIdQuery(id));
            return empresa is not null ? Ok(empresa) : NotFound();
        }

        [HttpGet("todas")]
        public async Task<IActionResult> ObtenerTodas()
        {
            var lista = await _mediator.Send(new ObtenerTodasEmpresasQuery());
            return Ok(lista);
        }

        [HttpGet("paginadas")]
        public async Task<IActionResult> ObtenerPaginadas([FromQuery] int pagina = 1, [FromQuery] int tamañoPagina = 10)
        {
            var lista = await _mediator.Send(new ObtenerEmpresasPaginadasQuery(pagina, tamañoPagina));
            return Ok(lista);
        }
    }
}
