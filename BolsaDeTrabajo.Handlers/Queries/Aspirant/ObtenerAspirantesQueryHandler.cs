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
    public class ObtenerAspirantesQueryHandler : IRequestHandler<ObtenerAspirantesQuery, List<Aspirante>>
    {
        private readonly IAspiranteRepo _repo;

        public ObtenerAspirantesQueryHandler(IAspiranteRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Aspirante>> Handle(ObtenerAspirantesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerTodosAsync(cancellationToken);
        }
    }
}
