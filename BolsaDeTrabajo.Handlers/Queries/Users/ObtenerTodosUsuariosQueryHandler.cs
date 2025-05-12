using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.usuarioQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Users
{
    public class ObtenerTodosUsuariosQueryHandler : IRequestHandler<ObtenerTodosUsuariosQuery, List<Models.Usuario>>
    {
        private readonly IUsuarioRepo _repo;

        public ObtenerTodosUsuariosQueryHandler(IUsuarioRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Models.Usuario>> Handle(ObtenerTodosUsuariosQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerTodosAsync(cancellationToken);
        }
    }

}
