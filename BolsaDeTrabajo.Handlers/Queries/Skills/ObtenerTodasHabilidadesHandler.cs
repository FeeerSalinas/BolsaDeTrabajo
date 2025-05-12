using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.habilidadQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Skills
{
    public class ObtenerTodasHabilidadesHandler : IRequestHandler<ObtenerTodasHabilidadesQuery, List<Habilidad>>
    {
        private readonly IHabilidadRepo _repo;

        public ObtenerTodasHabilidadesHandler(IHabilidadRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Habilidad>> Handle(ObtenerTodasHabilidadesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerTodasAsync(cancellationToken);
        }
    }
}
