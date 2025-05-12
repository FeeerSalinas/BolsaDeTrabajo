using BolsaDeTrabajo.Commands;
using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static BolsaDeTrabajo.Commands.usuarioCommands;

namespace BolsaDeTrabajo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepo _repo;

        public UsuarioController(IMediator mediator, IUsuarioRepo repo)
        {
            _mediator = mediator;
            _repo = repo;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioCommand command)
        {
            var token = await _mediator.Send(command);

            if (token is null)
                return Unauthorized("Credenciales inválidas");

            return Ok(new { token });
        }



        /// <summary>Crear un nuevo usuario</summary>
        [HttpPost("crear")]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Crear([FromBody] CrearUsuarioCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(ObtenerPorId), new { id }, new { id });
        }

        /// <summary>Editar usuario</summary>
        [HttpPut("editar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Editar([FromBody] EditarUsuarioCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok() : NotFound();
        }

        /// <summary>Eliminar usuario</summary>
        [HttpDelete("eliminar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _mediator.Send(new EliminarUsuarioCommand(id));
            return result ? Ok() : NotFound();
        }

        /// <summary>Obtener usuario por ID</summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId(int id, CancellationToken cancellationToken)
        {
            var usuario = await _repo.ObtenerPorIdAsync(id, cancellationToken);
            return usuario is null ? NotFound() : Ok(usuario);
        }

        /// <summary>Obtener todos los usuarios</summary>
        [HttpGet("todos")]
        [ProducesResponseType(typeof(List<Usuario>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodos(CancellationToken cancellationToken)
        {
            var usuarios = await _repo.ObtenerTodosAsync(cancellationToken);
            return Ok(usuarios);
        }

        /// <summary>Obtener usuarios paginados</summary>
        [HttpGet("paginado")]
        [ProducesResponseType(typeof(List<Usuario>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerPaginado([FromQuery] int page = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var usuarios = await _repo.ObtenerPaginadoAsync(page, pageSize, cancellationToken);
            return Ok(usuarios);
        }
    }
}
