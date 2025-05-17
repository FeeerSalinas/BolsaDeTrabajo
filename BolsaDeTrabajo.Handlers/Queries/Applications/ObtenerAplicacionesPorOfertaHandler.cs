using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.aplicacionQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Applications
{
    public class ObtenerAplicacionesPorOfertaHandler : IRequestHandler<ObtenerAplicacionesPorOfertaQuery, List<AplicacionOferta>>
    {
        private readonly IAplicacionOfertaRepo _repo;

        public ObtenerAplicacionesPorOfertaHandler(IAplicacionOfertaRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<AplicacionOferta>> Handle(ObtenerAplicacionesPorOfertaQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorOfertaAsync(request.IdOferta, cancellationToken);
        }
    }
}
