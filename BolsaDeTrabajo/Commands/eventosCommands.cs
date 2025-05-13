using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public class eventosCommands
    {
        public record CrearEventoCommand(
            int IdAspirante,
            string NombreEvento,
            string TipoEvento,
            string Pais,
            string Anfitrion,
            DateTime FechaEvento) : IRequest<bool>;

        public record EditarEventoCommand(
            int IdEvento,
            int IdAspirante,
            string NombreEvento,
            string TipoEvento,
            string Pais,
            string Anfitrion,
            DateTime FechaEvento) : IRequest<bool>;

        public record EliminarEventoCommand(int IdEvento) : IRequest<bool>;

    }
}
