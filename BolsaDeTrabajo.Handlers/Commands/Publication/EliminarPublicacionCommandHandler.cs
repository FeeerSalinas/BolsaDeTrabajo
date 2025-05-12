using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.publicacionCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Publication
{
    public class EliminarPublicacionCommandHandler : IRequestHandler<EliminarPublicacionCommand, bool>
    {
        private readonly IPublicacionRepo _repo;

        public EliminarPublicacionCommandHandler(IPublicacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EliminarPublicacionCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdPublicacion, cancellationToken);
        }
    }
}
