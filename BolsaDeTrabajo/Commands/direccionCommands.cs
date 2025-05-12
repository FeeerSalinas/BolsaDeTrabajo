using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public class direccionCommands
    {
        public record CrearDireccionCommand(int IdUsuario, string Departamento, string Municipio, string DetalleDireccion) : IRequest<bool>;

        public record EditarDireccionCommand(int IdUsuario, string Departamento, string Municipio, string DetalleDireccion) : IRequest<bool>;

        public record EliminarDireccionCommand(int IdUsuario) : IRequest<bool>;
    }
}
