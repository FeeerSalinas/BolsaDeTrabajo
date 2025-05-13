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
    public class EditarIdiomaCommandHandler : IRequestHandler<EditarIdiomaCommand, bool>
    {
        private readonly IIdiomaRepo _repo;

        public EditarIdiomaCommandHandler(IIdiomaRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EditarIdiomaCommand request, CancellationToken cancellationToken)
        {
            var idioma = new Idioma(
                request.IdAspirante,
                request.NombreIdioma,
                request.NivelLectura,
                request.NivelEscritura,
                request.NivelConversacion,
                request.NivelEscucha
            )
            {
                IdIdioma = request.IdIdioma
            };

            idioma.Validate();
            return await _repo.EditarAsync(idioma, cancellationToken);
        }
    }
}
