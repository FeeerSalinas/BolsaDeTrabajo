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
    public class ObtenerEmpresasPaginadasQueryHandler : IRequestHandler<ObtenerEmpresasPaginadasQuery, List<Empresa>>
    {
        private readonly IEmpresaRepo _repo;
        public ObtenerEmpresasPaginadasQueryHandler(IEmpresaRepo repo) => _repo = repo;

        public Task<List<Empresa>> Handle(ObtenerEmpresasPaginadasQuery request, CancellationToken cancellationToken) =>
            _repo.ObtenerPaginadasAsync(request.Pagina, request.TamañoPagina, cancellationToken);
    }
}
