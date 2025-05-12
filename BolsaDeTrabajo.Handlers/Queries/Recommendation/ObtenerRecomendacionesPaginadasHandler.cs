using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.recomendacionQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Recommendation
{
    public class ObtenerRecomendacionesPaginadasHandler : IRequestHandler<ObtenerRecomendacionesPaginadasQuery, List<Recomendacion>>
    {
        private readonly IRecomendacionRepo _repo;

        public ObtenerRecomendacionesPaginadasHandler(IRecomendacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Recomendacion>> Handle(ObtenerRecomendacionesPaginadasQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPaginadoAsync(request.Page, request.PageSize, cancellationToken);
        }
    }
}
