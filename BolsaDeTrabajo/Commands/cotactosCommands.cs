using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public class cotactosCommands
    {
        public record CrearContactoCommand(int IdUsuario, string TelefonoPersonal, string TelefonoFijo) : IRequest<bool>;

        public record EditarContactoCommand(int IdUsuario, string TelefonoPersonal, string TelefonoFijo) : IRequest<bool>;

        public record EliminarContactoCommand(int IdUsuario) : IRequest<bool>;
    }
}
