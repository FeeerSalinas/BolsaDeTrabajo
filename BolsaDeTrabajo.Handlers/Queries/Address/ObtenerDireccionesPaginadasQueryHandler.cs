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
    public class ObtenerDireccionesPaginadasQueryHandler : IRequestHandler<ObtenerDireccionesPaginadasQuery, List<Direccion>>
    {
        private readonly IDireccionRepo _repo;

        public ObtenerDireccionesPaginadasQueryHandler(IDireccionRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Direccion>> Handle(ObtenerDireccionesPaginadasQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPaginadasAsync(request.Page, request.PageSize, cancellationToken);
        }
    }
}
