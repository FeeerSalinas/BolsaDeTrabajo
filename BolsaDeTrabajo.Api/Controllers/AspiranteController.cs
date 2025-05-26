// ===================================================
// AspiranteController.cs - Compatible con queries existentes
// ===================================================
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BolsaDeTrabajo.Commands;
using BolsaDeTrabajo.Queries;
using static BolsaDeTrabajo.Commands.aspiranteCommands;
using static BolsaDeTrabajo.Queries.aspiranteQueries;

namespace BolsaDeTrabajo.Controllers
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
        public async Task<ActionResult<int>> Crear([FromBody] CrearAspiranteCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear aspirante: {ex.Message}");
            }
        }

        [HttpPut("editar")]
        public async Task<ActionResult<bool>> Editar([FromBody] EditarAspiranteCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al editar aspirante: {ex.Message}");
            }
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<bool>> Eliminar(int id)
        {
            try
            {
                var command = new EliminarAspiranteCommand(id);
                var resultado = await _mediator.Send(command);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar aspirante: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> ObtenerPorId(int id)
        {
            try
            {
                var query = new ObtenerAspirantePorIdQuery(id);
                var resultado = await _mediator.Send(query);

                if (resultado == null)
                    return NotFound("Aspirante no encontrado");

                // 🆕 MAPEAR TODOS LOS CAMPOS INCLUYENDO LOS NUEVOS
                return Ok(new
                {
                    idAspirante = resultado.IdAspirante,
                    idUsuario = resultado.IdUsuario,
                    primerNombre = resultado.PrimerNombre,
                    segundoNombre = resultado.SegundoNombre,
                    primerApellido = resultado.PrimerApellido,
                    segundoApellido = resultado.SegundoApellido,
                    puestoBusca = resultado.PuestoBusca,
                    // 🆕 NUEVOS CAMPOS EN LA RESPUESTA
                    genero = resultado.Genero,
                    fechaNacimiento = resultado.FechaNacimiento,
                    tipoDocumentoIdentidad = resultado.TipoDocumentoIdentidad,
                    numeroDocumentoIdentidad = resultado.NumeroDocumentoIdentidad,
                    nit = resultado.Nit,
                    nup = resultado.Nup
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener aspirante: {ex.Message}");
            }
        }

        // ✅ USAR LA QUERY EXISTENTE ObtenerAspirantesQuery
        [HttpGet("todos")]
        public async Task<ActionResult<List<object>>> ObtenerTodos()
        {
            try
            {
                var query = new ObtenerAspirantesQuery();
                var resultado = await _mediator.Send(query);

                // 🆕 MAPEAR TODOS LOS CAMPOS INCLUYENDO LOS NUEVOS
                var aspirantesFormateados = resultado.Select(a => new
                {
                    idAspirante = a.IdAspirante,
                    idUsuario = a.IdUsuario,
                    primerNombre = a.PrimerNombre,
                    segundoNombre = a.SegundoNombre,
                    primerApellido = a.PrimerApellido,
                    segundoApellido = a.SegundoApellido,
                    puestoBusca = a.PuestoBusca,
                    // 🆕 NUEVOS CAMPOS EN LA RESPUESTA
                    genero = a.Genero,
                    fechaNacimiento = a.FechaNacimiento,
                    tipoDocumentoIdentidad = a.TipoDocumentoIdentidad,
                    numeroDocumentoIdentidad = a.NumeroDocumentoIdentidad,
                    nit = a.Nit,
                    nup = a.Nup
                }).ToList();

                return Ok(aspirantesFormateados);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener aspirantes: {ex.Message}");
            }
        }

        // 🆕 NUEVO ENDPOINT PARA OBTENER POR USUARIO
        [HttpGet("usuario/{idUsuario}")]
        public async Task<ActionResult<object>> ObtenerPorUsuario(int idUsuario)
        {
            try
            {
                var query = new ObtenerAspirantePorUsuarioQuery(idUsuario);
                var resultado = await _mediator.Send(query);

                if (resultado == null)
                    return NotFound("Aspirante no encontrado para este usuario");

                // 🆕 MAPEAR TODOS LOS CAMPOS INCLUYENDO LOS NUEVOS
                return Ok(new
                {
                    idAspirante = resultado.IdAspirante,
                    idUsuario = resultado.IdUsuario,
                    primerNombre = resultado.PrimerNombre,
                    segundoNombre = resultado.SegundoNombre,
                    primerApellido = resultado.PrimerApellido,
                    segundoApellido = resultado.SegundoApellido,
                    puestoBusca = resultado.PuestoBusca,
                    // 🆕 NUEVOS CAMPOS EN LA RESPUESTA
                    genero = resultado.Genero,
                    fechaNacimiento = resultado.FechaNacimiento,
                    tipoDocumentoIdentidad = resultado.TipoDocumentoIdentidad,
                    numeroDocumentoIdentidad = resultado.NumeroDocumentoIdentidad,
                    nit = resultado.Nit,
                    nup = resultado.Nup
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener aspirante por usuario: {ex.Message}");
            }
        }

        // ✅ CONSERVAR ENDPOINTS EXISTENTES
        [HttpGet("paginados")]
        public async Task<ActionResult<List<object>>> ObtenerPaginados([FromQuery] int pagina = 1, [FromQuery] int tamanoPagina = 10)
        {
            try
            {
                var query = new ObtenerAspirantesPaginadosQuery(pagina, tamanoPagina);
                var resultado = await _mediator.Send(query);

                // 🆕 MAPEAR INCLUYENDO NUEVOS CAMPOS
                var aspirantesFormateados = resultado.Select(a => new
                {
                    idAspirante = a.IdAspirante,
                    idUsuario = a.IdUsuario,
                    primerNombre = a.PrimerNombre,
                    segundoNombre = a.SegundoNombre,
                    primerApellido = a.PrimerApellido,
                    segundoApellido = a.SegundoApellido,
                    puestoBusca = a.PuestoBusca,
                    // 🆕 NUEVOS CAMPOS
                    genero = a.Genero,
                    fechaNacimiento = a.FechaNacimiento,
                    tipoDocumentoIdentidad = a.TipoDocumentoIdentidad,
                    numeroDocumentoIdentidad = a.NumeroDocumentoIdentidad,
                    nit = a.Nit,
                    nup = a.Nup
                }).ToList();

                return Ok(aspirantesFormateados);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener aspirantes paginados: {ex.Message}");
            }
        }

        [HttpGet("por-puesto/{puesto}")]
        public async Task<ActionResult<List<object>>> ObtenerPorPuesto(string puesto)
        {
            try
            {
                var query = new ObtenersAspirantesPorPuesto(puesto);
                var resultado = await _mediator.Send(query);

                // 🆕 MAPEAR INCLUYENDO NUEVOS CAMPOS
                var aspirantesFormateados = resultado.Select(a => new
                {
                    idAspirante = a.IdAspirante,
                    idUsuario = a.IdUsuario,
                    primerNombre = a.PrimerNombre,
                    segundoNombre = a.SegundoNombre,
                    primerApellido = a.PrimerApellido,
                    segundoApellido = a.SegundoApellido,
                    puestoBusca = a.PuestoBusca,
                    // 🆕 NUEVOS CAMPOS
                    genero = a.Genero,
                    fechaNacimiento = a.FechaNacimiento,
                    tipoDocumentoIdentidad = a.TipoDocumentoIdentidad,
                    numeroDocumentoIdentidad = a.NumeroDocumentoIdentidad,
                    nit = a.Nit,
                    nup = a.Nup
                }).ToList();

                return Ok(aspirantesFormateados);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener aspirantes por puesto: {ex.Message}");
            }
        }

        // 🆕 NUEVOS ENDPOINTS PARA BÚSQUEDAS ESPECÍFICAS
        [HttpGet("por-documento/{numeroDocumento}")]
        public async Task<ActionResult<object>> ObtenerPorDocumento(string numeroDocumento)
        {
            try
            {
                var query = new ObtenerAspirantePorDocumentoQuery(numeroDocumento);
                var resultado = await _mediator.Send(query);

                if (resultado == null)
                    return NotFound("Aspirante no encontrado con ese documento");

                return Ok(new
                {
                    idAspirante = resultado.IdAspirante,
                    idUsuario = resultado.IdUsuario,
                    primerNombre = resultado.PrimerNombre,
                    segundoNombre = resultado.SegundoNombre,
                    primerApellido = resultado.PrimerApellido,
                    segundoApellido = resultado.SegundoApellido,
                    puestoBusca = resultado.PuestoBusca,
                    genero = resultado.Genero,
                    fechaNacimiento = resultado.FechaNacimiento,
                    tipoDocumentoIdentidad = resultado.TipoDocumentoIdentidad,
                    numeroDocumentoIdentidad = resultado.NumeroDocumentoIdentidad,
                    nit = resultado.Nit,
                    nup = resultado.Nup
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener aspirante por documento: {ex.Message}");
            }
        }

        [HttpGet("por-rango-edad")]
        public async Task<ActionResult<List<object>>> ObtenerPorRangoEdad([FromQuery] int edadMinima, [FromQuery] int edadMaxima)
        {
            try
            {
                var query = new ObtenerAspirantesPorRangoEdadQuery(edadMinima, edadMaxima);
                var resultado = await _mediator.Send(query);

                var aspirantesFormateados = resultado.Select(a => new
                {
                    idAspirante = a.IdAspirante,
                    idUsuario = a.IdUsuario,
                    primerNombre = a.PrimerNombre,
                    segundoNombre = a.SegundoNombre,
                    primerApellido = a.PrimerApellido,
                    segundoApellido = a.SegundoApellido,
                    puestoBusca = a.PuestoBusca,
                    genero = a.Genero,
                    fechaNacimiento = a.FechaNacimiento,
                    tipoDocumentoIdentidad = a.TipoDocumentoIdentidad,
                    numeroDocumentoIdentidad = a.NumeroDocumentoIdentidad,
                    nit = a.Nit,
                    nup = a.Nup,
                    // Calcular edad
                    edad = a.FechaNacimiento.HasValue ?
                        DateTime.Today.Year - a.FechaNacimiento.Value.Year -
                        (DateTime.Today < a.FechaNacimiento.Value.AddYears(DateTime.Today.Year - a.FechaNacimiento.Value.Year) ? 1 : 0)
                        : (int?)null
                }).ToList();

                return Ok(aspirantesFormateados);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener aspirantes por rango de edad: {ex.Message}");
            }
        }
    }
}