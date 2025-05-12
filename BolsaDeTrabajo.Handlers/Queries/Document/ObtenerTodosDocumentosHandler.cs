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
    public class ObtenerTodosDocumentosHandler : IRequestHandler<ObtenerTodosDocumentosQuery, List<DocumentosAspirante>>
    {
        private readonly IDocumentoRepo _repo;

        public ObtenerTodosDocumentosHandler(IDocumentoRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<DocumentosAspirante>> Handle(ObtenerTodosDocumentosQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerTodosAsync(cancellationToken);
        }
    }
}
