using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public class documentosCommands
    {
        public record CrearDocumentoCommand(int IdAspirante, string TipoDocumento, string NumeroDocumento) : IRequest<bool>;

        public record EditarDocumentoCommand(int IdAspirante, string TipoDocumento, string NumeroDocumento) : IRequest<bool>;

        public record EliminarDocumentoCommand(int IdAspirante) : IRequest<bool>;
    }
}
