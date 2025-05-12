using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BolsaDeTrabajo.Commands.documentosCommands;
using static BolsaDeTrabajo.Queries.documentsQueries;
using System.Security.Claims;

namespace BolsaDeTrabajo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DocumentosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAspiranteRepo _aspiranteRepo;

        public DocumentosController(IMediator mediator, IAspiranteRepo aspiranteRepo)
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Crear([FromBody] CrearDocumentoCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

            var creado = await _mediator.Send(command);
            return creado ? Ok("Documento creado") : BadRequest("No se pudo crear");
        }

        [HttpPut("editar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Editar([FromBody] EditarDocumentoCommand command)
        {
            if (!await EsAspiranteDelUsuario(command.IdAspirante)) return Forbid();

            var actualizado = await _mediator.Send(command);
            return actualizado ? Ok("Documento actualizado") : NotFound("No encontrado");
        }

        [HttpDelete("eliminar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Eliminar(int id)
        {
            if (!await EsAspiranteDelUsuario(id)) return Forbid();

            var eliminado = await _mediator.Send(new EliminarDocumentoCommand(id));
            return eliminado ? Ok("Eliminado") : NotFound("No encontrado");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DocumentosAspirante), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            if (!await EsAspiranteDelUsuario(id)) return Forbid();

            var documento = await _mediator.Send(new ObtenerDocumentoPorIdQuery(id));
            return documento is null ? NotFound("No encontrado") : Ok(documento);
        }

        [HttpGet("todos")]
        [ProducesResponseType(typeof(List<DocumentosAspirante>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodos()
        {
            var documentos = await _mediator.Send(new ObtenerTodosDocumentosQuery());
            return Ok(documentos);
        }

        [HttpGet("paginado")]
        [ProducesResponseType(typeof(List<DocumentosAspirante>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerPaginados([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var documentos = await _mediator.Send(new ObtenerDocumentosPaginadosQuery(page, pageSize));
            return Ok(documentos);
        }
    }
}
