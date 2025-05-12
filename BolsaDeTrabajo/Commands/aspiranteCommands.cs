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
        public record CrearAspiranteCommand(int IdUsuario, string PrimerNombre, string PrimerApellido, string? SegundoNombre, string? SegundoApellido) : IRequest<int>;

        public record EditarAspiranteCommand(int IdAspirante, int IdUsuario, string PrimerNombre, string PrimerApellido, string? SegundoNombre, string? SegundoApellido) : IRequest<bool>;

        public record EliminarAspiranteCommand(int IdAspirante) : IRequest<bool>;
    }
}
