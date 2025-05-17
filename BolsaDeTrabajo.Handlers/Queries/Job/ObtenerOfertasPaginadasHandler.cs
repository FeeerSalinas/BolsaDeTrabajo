using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.ofertaLaboralQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Job
{
    public class ObtenerOfertasPaginadasHandler : IRequestHandler<ObtenerOfertasPaginadasQuery, List<OfertaLaboral>>
    {
        private readonly IOfertaRepo _repo;

        public ObtenerOfertasPaginadasHandler(IOfertaRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<OfertaLaboral>> Handle(ObtenerOfertasPaginadasQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPaginadoAsync(request.Page, request.PageSize, cancellationToken);
        }
    }
}
