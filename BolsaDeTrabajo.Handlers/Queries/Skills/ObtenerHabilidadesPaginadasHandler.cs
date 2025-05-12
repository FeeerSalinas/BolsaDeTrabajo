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
    public class ObtenerHabilidadesPaginadasHandler : IRequestHandler<ObtenerHabilidadesPaginadasQuery, List<Habilidad>>
    {
        private readonly IHabilidadRepo _repo;

        public ObtenerHabilidadesPaginadasHandler(IHabilidadRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Habilidad>> Handle(ObtenerHabilidadesPaginadasQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPaginadoAsync(request.Page, request.PageSize, cancellationToken);
        }
    }
}
