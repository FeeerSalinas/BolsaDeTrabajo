using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.aplicacionCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Applications
{
    public class EliminarAplicacionCommandHandler : IRequestHandler<EliminarAplicacionCommand, bool>
    {
        private readonly IAplicacionOfertaRepo _repo;

        public EliminarAplicacionCommandHandler(IAplicacionOfertaRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EliminarAplicacionCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdAplicacion, cancellationToken);
        }
    }
}
