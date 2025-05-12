using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public class recomendacionCommands
    {
        public record CrearRecomendacionCommand(int IdAspirante, string NombreRecomendador, string Relacion, string Telefono) : IRequest<bool>;
        public record EditarRecomendacionCommand(int IdRecomendacion, int IdAspirante, string NombreRecomendador, string Relacion, string Telefono) : IRequest<bool>;
        public record EliminarRecomendacionCommand(int IdRecomendacion) : IRequest<bool>;
    }
}
