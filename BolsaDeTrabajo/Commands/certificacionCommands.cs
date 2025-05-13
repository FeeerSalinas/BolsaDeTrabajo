using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public class certificacionCommands
    {
        public record CrearCertificacionCommand(
            int IdAspirante,
            string NombreCertificado,
            string Institucion,
            DateTime FechaInicio,
            DateTime? FechaFin,
            string? Resultado,
            string? CodigoCertificado
        ) : IRequest<bool>;

        public record EditarCertificacionCommand(
            int IdCertificacion,
            int IdAspirante,
            string NombreCertificado,
            string Institucion,
            DateTime FechaInicio,
            DateTime? FechaFin,
            string? Resultado,
            string? CodigoCertificado
        ) : IRequest<bool>;

        public record EliminarCertificacionCommand(int IdCertificacion) : IRequest<bool>;
    }
}
