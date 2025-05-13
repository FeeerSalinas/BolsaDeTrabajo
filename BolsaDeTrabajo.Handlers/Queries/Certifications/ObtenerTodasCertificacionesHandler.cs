using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using BolsaDeTrabajo.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Handlers.Queries.Certifications
{
    public class ObtenerTodasCertificacionesHandler : IRequestHandler<certificacionQueries.ObtenerTodasCertificacionesQuery, List<Certificacion>>
    {
        private readonly ICertificacionRepo _repo;

        public ObtenerTodasCertificacionesHandler(ICertificacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Certificacion>> Handle(certificacionQueries.ObtenerTodasCertificacionesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerTodasAsync(cancellationToken);
        }
    }
}
