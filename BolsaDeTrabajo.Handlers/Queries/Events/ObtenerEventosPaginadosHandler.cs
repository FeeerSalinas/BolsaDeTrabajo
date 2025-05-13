using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using BolsaDeTrabajo.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Handlers.Queries.Events
{
    public class ObtenerEventosPaginadosHandler : IRequestHandler<eventosQueries.ObtenerEventosPaginadosQuery, List<Evento>>
    {
        private readonly IEventoRepo _repo;

        public ObtenerEventosPaginadosHandler(IEventoRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Evento>> Handle(eventosQueries.ObtenerEventosPaginadosQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPaginadoAsync(request.Page, request.PageSize, cancellationToken);
        }
    }
}
