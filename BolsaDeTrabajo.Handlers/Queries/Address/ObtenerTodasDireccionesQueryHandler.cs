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
    public class ObtenerTodasDireccionesQueryHandler : IRequestHandler<ObtenerTodasDireccionesQuery, List<Direccion>>
    {
        private readonly IDireccionRepo _repo;

        public ObtenerTodasDireccionesQueryHandler(IDireccionRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Direccion>> Handle(ObtenerTodasDireccionesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerTodasAsync(cancellationToken);
        }
    }
}
