using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.aspiranteQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Aspirant
{
    public class ObtenersAspirantesPorPuestoHandler : IRequestHandler<ObtenersAspirantesPorPuesto, List<Aspirante>>
    {
        private readonly IAspiranteRepo _repo;

        public ObtenersAspirantesPorPuestoHandler(IAspiranteRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Aspirante>> Handle(ObtenersAspirantesPorPuesto request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerAspirantesPorPuesto(request.puestoBusca, cancellationToken);
        }
    }
}
