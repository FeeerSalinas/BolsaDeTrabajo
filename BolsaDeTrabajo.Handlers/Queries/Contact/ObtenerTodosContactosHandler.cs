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
    public class ObtenerTodosContactosHandler : IRequestHandler<ObtenerTodosContactosQuery, List<Contacto>>
    {
        private readonly IContactoRepo _repo;
        public ObtenerTodosContactosHandler(IContactoRepo repo) => _repo = repo;

        public async Task<List<Contacto>> Handle(ObtenerTodosContactosQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerTodosAsync(cancellationToken);
        }
    }
}
