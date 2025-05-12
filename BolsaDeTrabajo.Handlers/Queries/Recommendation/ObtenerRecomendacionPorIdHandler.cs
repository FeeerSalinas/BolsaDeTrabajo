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
    public class ObtenerRecomendacionPorIdHandler : IRequestHandler<ObtenerRecomendacionPorIdQuery, Recomendacion?>
    {
        private readonly IRecomendacionRepo _repo;

        public ObtenerRecomendacionPorIdHandler(IRecomendacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<Recomendacion?> Handle(ObtenerRecomendacionPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdRecomendacion, cancellationToken);
        }
    }
}
