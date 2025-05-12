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
    public class ObtenerDocumentosPaginadosHandler : IRequestHandler<ObtenerDocumentosPaginadosQuery, List<DocumentosAspirante>>
    {
        private readonly IDocumentoRepo _repo;

        public ObtenerDocumentosPaginadosHandler(IDocumentoRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<DocumentosAspirante>> Handle(ObtenerDocumentosPaginadosQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPaginadoAsync(request.Page, request.PageSize, cancellationToken);
        }
    }
}
