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
    public class ObtenerCertificacionesPaginadasHandler : IRequestHandler<certificacionQueries.ObtenerCertificacionesPaginadasQuery, List<Certificacion>>
    {
        private readonly ICertificacionRepo _repo;

        public ObtenerCertificacionesPaginadasHandler(ICertificacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Certificacion>> Handle(certificacionQueries.ObtenerCertificacionesPaginadasQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPaginadoAsync(request.Page, request.PageSize, cancellationToken);
        }
    }
}
