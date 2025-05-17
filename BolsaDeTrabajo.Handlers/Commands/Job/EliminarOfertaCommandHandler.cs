using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.ofertaLaboralCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Job
{
    public class EliminarOfertaCommandHandler : IRequestHandler<EliminarOfertaCommand, bool>
    {
        private readonly IOfertaRepo _repo;

        public EliminarOfertaCommandHandler(IOfertaRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EliminarOfertaCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdOferta, cancellationToken);
        }
    }
}
