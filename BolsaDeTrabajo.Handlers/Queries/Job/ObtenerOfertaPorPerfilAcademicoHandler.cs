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
    public class ObtenerOfertaPorPerfilAcademicoHandler : IRequestHandler<ObtenerOfertaPorPerfilAcademico, List<OfertaLaboral>>
    {
        private readonly IOfertaRepo _repo;

        public ObtenerOfertaPorPerfilAcademicoHandler(IOfertaRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<OfertaLaboral>> Handle(ObtenerOfertaPorPerfilAcademico request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerOfertaPorPerfil(request.perfilAcademico, cancellationToken);
        }
    }
}
