using BolsaDeTrabajo.Commands;
using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Handlers.Commands.Languages
{
    public class CrearIdiomaCommandHandler : IRequestHandler<CrearIdiomaCommand, bool>
    {
        private readonly IIdiomaRepo _repo;

        public CrearIdiomaCommandHandler(IIdiomaRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(CrearIdiomaCommand request, CancellationToken cancellationToken)
        {
            var idioma = new Idioma(
                request.IdAspirante,
                request.NombreIdioma,
                request.NivelLectura,
                request.NivelEscritura,
                request.NivelConversacion,
                request.NivelEscucha
            );

            idioma.Validate();
            return await _repo.CrearAsync(idioma, cancellationToken);
        }
    }
}
