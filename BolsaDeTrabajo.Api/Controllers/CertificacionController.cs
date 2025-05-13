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
    public class CertificacionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAspiranteRepo _aspiranteRepo;

        public CertificacionController(IMediator mediator, IAspiranteRepo aspiranteRepo)
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
        public async Task<IActionResult> Crear([FromBody] certificacionCommands.CrearCertificacionCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

            var creado = await _mediator.Send(command);
            return creado ? Ok("Certificación creada") : BadRequest("No se pudo crear");
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] certificacionCommands.EditarCertificacionCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

            var actualizado = await _mediator.Send(command);
            return actualizado ? Ok("Certificación actualizada") : NotFound("No encontrada");
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var cert = await _mediator.Send(new certificacionQueries.ObtenerCertificacionPorIdQuery(id));
            if (cert is null || !await EsAspiranteDelUsuario(cert.IdAspirante)) return Forbid();

            var eliminado = await _mediator.Send(new certificacionCommands.EliminarCertificacionCommand(id));
            return eliminado ? Ok("Eliminado") : NotFound("No encontrado");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var cert = await _mediator.Send(new certificacionQueries.ObtenerCertificacionPorIdQuery(id));
            if (cert is null || !await EsAspiranteDelUsuario(cert.IdAspirante)) return Forbid();

            return Ok(cert);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            var lista = await _mediator.Send(new certificacionQueries.ObtenerTodasCertificacionesQuery());
            return Ok(lista);
        }

        [HttpGet("paginado")]
        public async Task<IActionResult> ObtenerPaginado([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var lista = await _mediator.Send(new certificacionQueries.ObtenerCertificacionesPaginadasQuery(page, pageSize));
            return Ok(lista);
        }
    }
}
