using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public class logroCommands
    {
        public record CrearLogroCommand(int IdAspirante, string DescripcionLogro, DateTime FechaLogro, string? TipoLogro) : IRequest<bool>;
        public record EditarLogroCommand(int IdLogro, int IdAspirante, string DescripcionLogro, DateTime FechaLogro, string? TipoLogro) : IRequest<bool>;
        public record EliminarLogroCommand(int IdLogro) : IRequest<bool>;
    }
}
