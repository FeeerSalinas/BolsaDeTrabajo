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
    public class ObtenerPublicacionPorIdHandler : IRequestHandler<ObtenerPublicacionPorIdQuery, Publicacion?>
    {
        private readonly IPublicacionRepo _repo;

        public ObtenerPublicacionPorIdHandler(IPublicacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<Publicacion?> Handle(ObtenerPublicacionPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdPublicacion, cancellationToken);
        }
    }
}
