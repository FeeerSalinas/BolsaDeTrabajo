using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public class publicacionCommands
    {
        public record CrearPublicacionCommand(
            int IdAspirante,
            string TipoPublicacion,
            string Titulo,
            string LugarPublicacion,
            DateTime FechaPublicacion,
            string? Isbn
        ) : IRequest<bool>;

        public record EditarPublicacionCommand(
            int IdPublicacion,
            int IdAspirante,
            string TipoPublicacion,
            string Titulo,
            string LugarPublicacion,
            DateTime FechaPublicacion,
            string? Isbn
        ) : IRequest<bool>;

        public record EliminarPublicacionCommand(int IdPublicacion) : IRequest<bool>;
    }
}
