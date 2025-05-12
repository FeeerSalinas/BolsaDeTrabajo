using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.documentosCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Document
{
    public class EditarDocumentoCommandHandler : IRequestHandler<EditarDocumentoCommand, bool>
    {
        private readonly IDocumentoRepo _repo;

        public EditarDocumentoCommandHandler(IDocumentoRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EditarDocumentoCommand request, CancellationToken cancellationToken)
        {
            var doc = new DocumentosAspirante(request.IdAspirante, request.TipoDocumento, request.NumeroDocumento);
            doc.Validate();
            return await _repo.EditarAsync(doc, cancellationToken);
        }
    }
}
