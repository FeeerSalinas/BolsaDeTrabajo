using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public class aplicacionCommands
    {
        public record CrearAplicacionCommand(int IdOferta, int IdAspirante, DateTime FechaAplicacion, string Estado) : IRequest<bool>;

        public record EditarAplicacionCommand(int IdAplicacion, int IdOferta, int IdAspirante, DateTime FechaAplicacion, string Estado) : IRequest<bool>;

        public record EliminarAplicacionCommand(int IdAplicacion) : IRequest<bool>;
    }
}
