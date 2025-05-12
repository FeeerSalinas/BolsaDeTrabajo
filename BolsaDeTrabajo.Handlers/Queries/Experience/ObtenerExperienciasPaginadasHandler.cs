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
    public class ObtenerExperienciasPaginadasHandler : IRequestHandler<ObtenerExperienciasPaginadasQuery, List<ExperienciaLaboral>>
    {
        private readonly IExperienciaRepo _repo;

        public ObtenerExperienciasPaginadasHandler(IExperienciaRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<ExperienciaLaboral>> Handle(ObtenerExperienciasPaginadasQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPaginadoAsync(request.Page, request.PageSize, cancellationToken);
        }
    }
}
