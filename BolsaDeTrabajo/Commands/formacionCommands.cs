using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public class formacionCommands
    {
        public record CrearFormacionCommand(
            int IdAspirante,
            string Institucion,
            string Titulo,
            DateTime FechaInicio,
            string TipoFormacion,
            DateTime? FechaFin = null
        ) : IRequest<bool>;

        public record EditarFormacionCommand(
            int IdFormacion,
            int IdAspirante,
            string Institucion,
            string Titulo,
            DateTime FechaInicio,
            string TipoFormacion,
            DateTime? FechaFin = null
        ) : IRequest<bool>;

        public record EliminarFormacionCommand(int IdFormacion) : IRequest<bool>;
    }
}
