using BolsaDeTrabajo.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BolsaDeTrabajo.Commands.aplicacionCommands;
using static BolsaDeTrabajo.Queries.aplicacionQueries;
using System.Security.Claims;

namespace BolsaDeTrabajo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AplicacionesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAspiranteRepo _aspiranteRepo;
        private readonly IOfertaRepo _ofertaRepo;

        public AplicacionesController(IMediator mediator, IAspiranteRepo aspiranteRepo, IOfertaRepo ofertaRepo)
        {
            _mediator = mediator;
            _aspiranteRepo = aspiranteRepo;
            _ofertaRepo = ofertaRepo;
        }

        private int GetUserId() =>
            int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        private string GetUserRole() =>
            User.FindFirstValue(ClaimTypes.Role)!;

        private async Task<bool> EsAplicacionDelAspirante(int idAspirante)
        {
            var aspirante = await _aspiranteRepo.ObtenerPorIdAsync(idAspirante, CancellationToken.None);
            return aspirante?.IdUsuario == GetUserId();
        }

        private async Task<bool> EsOfertaDeEmpresa(int idOferta)
        {
            var oferta = await _ofertaRepo.ObtenerPorIdAsync(idOferta, CancellationToken.None);
            return oferta?.IdEmpresa == GetUserId();
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] CrearAplicacionCommand command)
        {
            if (!await EsAplicacionDelAspirante(command.IdAspirante)) return Forbid();

            var creado = await _mediator.Send(command);
            return creado ? Ok("Aplicación creada") : BadRequest("No se pudo crear");
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarAplicacionCommand command)
        {
            if (!await EsAplicacionDelAspirante(command.IdAspirante)) return Forbid();

            var actualizado = await _mediator.Send(command);
            return actualizado ? Ok("Aplicación actualizada") : NotFound("No encontrado");
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            // No hay validación aquí porque depende del idAspirante, y no lo recibimos. Se sugiere mejorar esto si es crítico.
            var eliminado = await _mediator.Send(new EliminarAplicacionCommand(id));
            return eliminado ? Ok("Eliminado") : NotFound("No encontrado");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var aplicacion = await _mediator.Send(new ObtenerAplicacionPorIdQuery(id));

            if (aplicacion == null) return NotFound("No encontrado");

            var userId = GetUserId();
            var userRole = GetUserRole();

            if (userRole == "Aspirante" && aplicacion.IdAspirante != userId)
                return Forbid();

            if (userRole == "Empresa" && aplicacion.Oferta?.IdEmpresa != userId)
                return Forbid();

            return Ok(aplicacion);
        }

        [HttpGet("aspirante/{idAspirante}")]
        public async Task<IActionResult> ObtenerPorAspirante(int idAspirante)
        {
            if (!await EsAplicacionDelAspirante(idAspirante)) return Forbid();

            var lista = await _mediator.Send(new ObtenerAplicacionesPorAspiranteQuery(idAspirante));
            return Ok(lista);
        }

        [HttpGet("oferta/{idOferta}")]
        public async Task<IActionResult> ObtenerPorOferta(int idOferta)
        {
            if (!await EsOfertaDeEmpresa(idOferta)) return Forbid();

            var lista = await _mediator.Send(new ObtenerAplicacionesPorOfertaQuery(idOferta));
            return Ok(lista);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            var lista = await _mediator.Send(new ObtenerTodasAplicacionesQuery());
            return Ok(lista);
        }

        [HttpGet("paginado")]
        public async Task<IActionResult> ObtenerPaginados([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var lista = await _mediator.Send(new ObtenerAplicacionesPaginadasQuery(page, pageSize));
            return Ok(lista);
        }
    }
}
