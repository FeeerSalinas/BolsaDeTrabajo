using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.logroQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Achievements
{
    public class ObtenerLogrosPaginadosHandler : IRequestHandler<ObtenerLogrosPaginadosQuery, List<Logro>>
    {
        private readonly ILogroRepo _repo;

        public ObtenerLogrosPaginadosHandler(ILogroRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Logro>> Handle(ObtenerLogrosPaginadosQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPaginadoAsync(request.Page, request.PageSize, cancellationToken);
        }
    }
}
