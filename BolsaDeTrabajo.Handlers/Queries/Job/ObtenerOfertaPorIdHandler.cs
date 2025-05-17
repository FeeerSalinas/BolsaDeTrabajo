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
    public class ObtenerOfertaPorIdHandler : IRequestHandler<ObtenerOfertaPorIdQuery, OfertaLaboral?>
    {
        private readonly IOfertaRepo _repo;

        public ObtenerOfertaPorIdHandler(IOfertaRepo repo)
        {
            _repo = repo;
        }

        public async Task<OfertaLaboral?> Handle(ObtenerOfertaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdOferta, cancellationToken);
        }
    }
}
