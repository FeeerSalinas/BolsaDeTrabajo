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
    public class ObtenerContactoPorIdHandler : IRequestHandler<ObtenerContactoPorIdQuery, Contacto?>
    {
        private readonly IContactoRepo _repo;
        public ObtenerContactoPorIdHandler(IContactoRepo repo) => _repo = repo;

        public async Task<Contacto?> Handle(ObtenerContactoPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdUsuario, cancellationToken);
        }
    }
}
