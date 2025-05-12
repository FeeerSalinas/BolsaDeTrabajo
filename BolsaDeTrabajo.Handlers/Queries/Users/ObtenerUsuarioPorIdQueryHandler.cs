using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.usuarioQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Usuario
{
    public class ObtenerUsuarioPorIdQueryHandler : IRequestHandler<ObtenerUsuarioPorIdQuery, Models.Usuario?>
    {
        private readonly IUsuarioRepo _repo;

        public ObtenerUsuarioPorIdQueryHandler(IUsuarioRepo repo)
        {
            _repo = repo;
        }

        public async Task<Models.Usuario?> Handle(ObtenerUsuarioPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdUsuario, cancellationToken);
        }
    }
}
