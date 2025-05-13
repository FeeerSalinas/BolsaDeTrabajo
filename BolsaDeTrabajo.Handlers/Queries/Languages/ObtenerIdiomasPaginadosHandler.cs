using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.idiomaQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Languages
{
    public class ObtenerIdiomasPaginadosHandler : IRequestHandler<ObtenerIdiomasPaginadosQuery, List<Idioma>>
    {
        private readonly IIdiomaRepo _repo;

        public ObtenerIdiomasPaginadosHandler(IIdiomaRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Idioma>> Handle(ObtenerIdiomasPaginadosQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPaginadoAsync(request.Page, request.PageSize, cancellationToken);
        }
    }
}
