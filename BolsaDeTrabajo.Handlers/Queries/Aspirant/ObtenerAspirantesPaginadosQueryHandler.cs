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
    public class ObtenerAspirantesPaginadosQueryHandler : IRequestHandler<ObtenerAspirantesPaginadosQuery, List<Aspirante>>
    {
        private readonly IAspiranteRepo _repo;

        public ObtenerAspirantesPaginadosQueryHandler(IAspiranteRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Aspirante>> Handle(ObtenerAspirantesPaginadosQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPaginadosAsync(request.Pagina, request.TamanoPagina, cancellationToken);
        }
    }
}
