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
    public class ObtenerCertificacionPorIdHandler : IRequestHandler<certificacionQueries.ObtenerCertificacionPorIdQuery, Certificacion?>
    {
        private readonly ICertificacionRepo _repo;

        public ObtenerCertificacionPorIdHandler(ICertificacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<Certificacion?> Handle(certificacionQueries.ObtenerCertificacionPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdCertificacion, cancellationToken);
        }
    }
}
