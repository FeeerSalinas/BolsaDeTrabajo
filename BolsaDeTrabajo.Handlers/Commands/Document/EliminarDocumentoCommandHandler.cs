using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.documentosCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Document
{
    public class EliminarDocumentoCommandHandler : IRequestHandler<EliminarDocumentoCommand, bool>
    {
        private readonly IDocumentoRepo _repo;

        public EliminarDocumentoCommandHandler(IDocumentoRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EliminarDocumentoCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdAspirante, cancellationToken);
        }
    }
}
