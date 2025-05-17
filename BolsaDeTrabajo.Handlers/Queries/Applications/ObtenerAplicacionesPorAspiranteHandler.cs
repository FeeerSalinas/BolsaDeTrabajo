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
    public class ObtenerAplicacionesPorAspiranteHandler : IRequestHandler<ObtenerAplicacionesPorAspiranteQuery, List<AplicacionOferta>>
    {
        private readonly IAplicacionOfertaRepo _repo;

        public ObtenerAplicacionesPorAspiranteHandler(IAplicacionOfertaRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<AplicacionOferta>> Handle(ObtenerAplicacionesPorAspiranteQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorAspiranteAsync(request.IdAspirante, cancellationToken);
        }
    }
}
