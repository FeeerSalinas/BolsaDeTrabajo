using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.aspiranteCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Aspirant
{
    public class EliminarAspiranteCommandHandler : IRequestHandler<EliminarAspiranteCommand, bool>
    {
        private readonly IAspiranteRepo _repo;

        public EliminarAspiranteCommandHandler(IAspiranteRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EliminarAspiranteCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdAspirante, cancellationToken);
        }
    }
}
