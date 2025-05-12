using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.experienciaQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Experience
{
    public class ObtenerTodasExperienciasHandler : IRequestHandler<ObtenerTodasExperienciasQuery, List<ExperienciaLaboral>>
    {
        private readonly IExperienciaRepo _repo;

        public ObtenerTodasExperienciasHandler(IExperienciaRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<ExperienciaLaboral>> Handle(ObtenerTodasExperienciasQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerTodasAsync(cancellationToken);
        }
    }
}
