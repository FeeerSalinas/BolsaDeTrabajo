using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.aspiranteCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Aspirant
{
    public class EditarAspiranteCommandHandler : IRequestHandler<EditarAspiranteCommand, bool>
    {
        private readonly IAspiranteRepo _repo;

        public EditarAspiranteCommandHandler(IAspiranteRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EditarAspiranteCommand request, CancellationToken cancellationToken)
        {
            var aspirante = new Aspirante(
                request.IdUsuario,
                request.PrimerNombre,
                request.PrimerApellido,
                request.SegundoNombre,
                request.SegundoApellido,
                request.PuestoBusca
            )
            {
                IdAspirante = request.IdAspirante
            };
            return await _repo.EditarAsync(aspirante, cancellationToken);
        }
    }
}
