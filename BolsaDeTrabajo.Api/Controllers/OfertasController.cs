using BolsaDeTrabajo.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BolsaDeTrabajo.Commands.ofertaLaboralCommands;
using static BolsaDeTrabajo.Queries.ofertaLaboralQueries;
using System.Security.Claims;

namespace BolsaDeTrabajo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Empresa")]
    public class OfertasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEmpresaRepo _empresaRepo;

        public OfertasController(IMediator mediator, IEmpresaRepo empresaRepo)
        {
            _mediator = mediator;
            _empresaRepo = empresaRepo;
        }

        private int GetUserId() =>
            int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        private async Task<bool> EsEmpresaDelUsuario(int idEmpresa)
        {
            var empresa = await _empresaRepo.ObtenerPorIdAsync(idEmpresa, CancellationToken.None);
            return empresa?.IdUsuario == GetUserId();
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] CrearOfertaCommand command)
        {
            if (!await EsEmpresaDelUsuario(command.IdEmpresa)) return Forbid();

            var creado = await _mediator.Send(command);
            return creado ? Ok("Oferta creada") : BadRequest("No se pudo crear");
        }

        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarOfertaCommand command)
        {
            if (!await EsEmpresaDelUsuario(command.IdEmpresa)) return Forbid();

            var actualizado = await _mediator.Send(command);
            return actualizado ? Ok("Oferta actualizada") : NotFound("No encontrada");
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            // Se obtiene la oferta para verificar el IdEmpresa antes de eliminar
            var oferta = await _mediator.Send(new ObtenerOfertaPorIdQuery(id));
            if (oferta == null) return NotFound("No encontrada");

            if (!await EsEmpresaDelUsuario(oferta.IdEmpresa)) return Forbid();

            var eliminado = await _mediator.Send(new EliminarOfertaCommand(id));
            return eliminado ? Ok("Eliminada") : BadRequest("No se pudo eliminar");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var oferta = await _mediator.Send(new ObtenerOfertaPorIdQuery(id));
            if (oferta == null) return NotFound("No encontrada");

            if (!await EsEmpresaDelUsuario(oferta.IdEmpresa)) return Forbid();

            return Ok(oferta);
        }

        [HttpGet("todas")]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerTodas()
        {
            var ofertas = await _mediator.Send(new ObtenerTodasOfertasQuery());
            return Ok(ofertas);
        }

        [HttpGet("paginado")]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerPaginadas([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var ofertas = await _mediator.Send(new ObtenerOfertasPaginadasQuery(page, pageSize));
            return Ok(ofertas);
        }

        [HttpGet("filtro-perfil-academico/{perfilAcademico}")]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerPorOfeta([FromRoute]string perfilAcademico)
        {
            var ofertas = await _mediator.Send(new ObtenerOfertaPorPerfilAcademico(perfilAcademico));
            return Ok(ofertas);
        }
    }
}
