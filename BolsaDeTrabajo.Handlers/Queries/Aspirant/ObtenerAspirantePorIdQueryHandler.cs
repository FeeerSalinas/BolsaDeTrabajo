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
    public class ObtenerAspirantePorIdQueryHandler : IRequestHandler<ObtenerAspirantePorIdQuery, Aspirante?>
    {
        private readonly IAspiranteRepo _repo;

        public ObtenerAspirantePorIdQueryHandler(IAspiranteRepo repo)
        {
            _repo = repo;
        }

        public async Task<Aspirante?> Handle(ObtenerAspirantePorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdAspirante, cancellationToken);
        }
    }
}
