using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public class aspiranteCommands
    {
        public record CrearAspiranteCommand(
            int IdUsuario,
            string PrimerNombre,
            string PrimerApellido,
            string? SegundoNombre,
            string? SegundoApellido,
            string? PuestoBusca,
            // 🆕 NUEVOS PARÁMETROS
            string? Genero = null,
            DateTime? FechaNacimiento = null,
            string? TipoDocumentoIdentidad = null,
            string? NumeroDocumentoIdentidad = null,
            string? Nit = null,
            string? Nup = null
        ) : IRequest<int>;

        public record EditarAspiranteCommand(
            int IdAspirante,
            int IdUsuario,
            string PrimerNombre,
            string PrimerApellido,
            string? SegundoNombre,
            string? SegundoApellido,
            string? PuestoBusca,
            // 🆕 NUEVOS PARÁMETROS
            string? Genero = null,
            DateTime? FechaNacimiento = null,
            string? TipoDocumentoIdentidad = null,
            string? NumeroDocumentoIdentidad = null,
            string? Nit = null,
            string? Nup = null
        ) : IRequest<bool>;

        public record EliminarAspiranteCommand(int IdAspirante) : IRequest<bool>;
    }
}