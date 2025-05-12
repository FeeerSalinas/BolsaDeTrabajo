using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public class habilidadCommands
    {
        public record CrearHabilidadCommand(
            int IdAspirante,
            string NombreHabilidad,
            string NivelDominio,
            string? Comentario
        ) : IRequest<bool>;

        public record EditarHabilidadCommand(
            int IdHabilidad,
            int IdAspirante,
            string NombreHabilidad,
            string NivelDominio,
            string? Comentario
        ) : IRequest<bool>;

        public record EliminarHabilidadCommand(int IdHabilidad) : IRequest<bool>;
    }
}
