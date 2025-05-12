using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public class EmpresaCommands
    {
        public record CrearEmpresaCommand(int IdUsuario, string NombreEmpresa, string NombreRepresentante, string? DescripcionEmpresa) : IRequest<int>;
        public record EditarEmpresaCommand(int IdEmpresa, int IdUsuario, string NombreEmpresa, string NombreRepresentante, string? DescripcionEmpresa) : IRequest<bool>;
        public record EliminarEmpresaCommand(int IdEmpresa) : IRequest<bool>;
    }
}
