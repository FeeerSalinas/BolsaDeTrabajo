using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.publicacionQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Publication
{
    public class ObtenerTodasPublicacionesHandler : IRequestHandler<ObtenerTodasPublicacionesQuery, List<Publicacion>>
    {
        private readonly IPublicacionRepo _repo;

        public ObtenerTodasPublicacionesHandler(IPublicacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Publicacion>> Handle(ObtenerTodasPublicacionesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerTodasAsync(cancellationToken);
        }
    }
}
