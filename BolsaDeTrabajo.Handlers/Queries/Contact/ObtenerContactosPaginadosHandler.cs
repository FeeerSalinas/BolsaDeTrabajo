using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using BolsaDeTrabajo.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.contactoQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Contact
{
    public class ObtenerContactosPaginadosHandler : IRequestHandler<ObtenerContactosPaginadosQuery, List<Contacto>>
    {
        private readonly IContactoRepo _repo;
        public ObtenerContactosPaginadosHandler(IContactoRepo repo) => _repo = repo;

        public async Task<List<Contacto>> Handle(ObtenerContactosPaginadosQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPaginadosAsync(request.Page, request.PageSize, cancellationToken);
        }
    }
}
