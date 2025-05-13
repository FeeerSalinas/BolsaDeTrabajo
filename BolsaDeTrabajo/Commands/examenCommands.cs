using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public class examenCommands
    {
        public record CrearExamenCommand(
            int IdAspirante,
            string TipoExamen,
            DateTime FechaRealizacion,
            decimal? ResultadoNumerico = null,
            string? ResultadoCualitativo = null
        ) : IRequest<bool>;

        public record EditarExamenCommand(
            int IdExamen,
            int IdAspirante,
            string TipoExamen,
            DateTime FechaRealizacion,
            decimal? ResultadoNumerico = null,
            string? ResultadoCualitativo = null
        ) : IRequest<bool>;

        public record EliminarExamenCommand(int IdExamen) : IRequest<bool>;
    }
}
