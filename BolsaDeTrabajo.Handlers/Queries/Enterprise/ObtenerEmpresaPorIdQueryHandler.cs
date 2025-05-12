using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.EmpresaQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Enterprise
{
    public class ObtenerEmpresaPorIdQueryHandler : IRequestHandler<ObtenerEmpresaPorIdQuery, Empresa?>
    {
        private readonly IEmpresaRepo _repo;
        public ObtenerEmpresaPorIdQueryHandler(IEmpresaRepo repo) => _repo = repo;

        public Task<Empresa?> Handle(ObtenerEmpresaPorIdQuery request, CancellationToken cancellationToken) =>
            _repo.ObtenerPorIdAsync(request.IdEmpresa, cancellationToken);
    }
}
