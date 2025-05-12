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
    public class CrearAspiranteCommandHandler : IRequestHandler<CrearAspiranteCommand, int>
    {
        private readonly IAspiranteRepo _repo;

        public CrearAspiranteCommandHandler(IAspiranteRepo repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CrearAspiranteCommand request, CancellationToken cancellationToken)
        {
            var aspirante = new Aspirante(
                request.IdUsuario,
                request.PrimerNombre,
                request.PrimerApellido,
                request.SegundoNombre,
                request.SegundoApellido
            );
            return await _repo.CrearAsync(aspirante, cancellationToken);
        }
    }
}
