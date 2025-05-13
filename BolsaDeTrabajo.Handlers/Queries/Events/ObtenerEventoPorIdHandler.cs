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
    public class ObtenerEventoPorIdHandler : IRequestHandler<eventosQueries.ObtenerEventoPorIdQuery, Evento?>
    {
        private readonly IEventoRepo _repo;

        public ObtenerEventoPorIdHandler(IEventoRepo repo)
        {
            _repo = repo;
        }

        public async Task<Evento?> Handle(eventosQueries.ObtenerEventoPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdEvento, cancellationToken);
        }
    }
}
