using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.direccionQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Address
{
    public class ObtenerDireccionPorIdQueryHandler : IRequestHandler<ObtenerDireccionPorIdQuery, Direccion?>
    {
        private readonly IDireccionRepo _repo;

        public ObtenerDireccionPorIdQueryHandler(IDireccionRepo repo)
        {
            _repo = repo;
        }

        public async Task<Direccion?> Handle(ObtenerDireccionPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdUsuario, cancellationToken);
        }
    }
}
