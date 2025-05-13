using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public record CrearIdiomaCommand(
            int IdAspirante,
            string NombreIdioma,
            string NivelLectura,
            string NivelEscritura,
            string NivelConversacion,
            string NivelEscucha
        ) : IRequest<bool>;

    public record EditarIdiomaCommand(
        int IdIdioma,
        int IdAspirante,
        string NombreIdioma,
        string NivelLectura,
        string NivelEscritura,
        string NivelConversacion,
        string NivelEscucha
    ) : IRequest<bool>;

    public record EliminarIdiomaCommand(int IdIdioma) : IRequest<bool>;

}
