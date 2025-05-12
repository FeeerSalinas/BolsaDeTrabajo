using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.documentsQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Document
{
    public class ObtenerDocumentoPorIdHandler : IRequestHandler<ObtenerDocumentoPorIdQuery, DocumentosAspirante?>
    {
        private readonly IDocumentoRepo _repo;

        public ObtenerDocumentoPorIdHandler(IDocumentoRepo repo)
        {
            _repo = repo;
        }

        public async Task<DocumentosAspirante?> Handle(ObtenerDocumentoPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdAspirante, cancellationToken);
        }
    }
}
