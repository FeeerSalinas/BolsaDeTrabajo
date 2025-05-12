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
    public class ObtenerUsuariosPaginadosQueryHandler : IRequestHandler<ObtenerUsuariosPaginadosQuery, List<Models.Usuario>>
    {
        private readonly IUsuarioRepo _repo;

        public ObtenerUsuariosPaginadosQueryHandler(IUsuarioRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Models.Usuario>> Handle(ObtenerUsuariosPaginadosQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPaginadoAsync(request.Page, request.PageSize, cancellationToken);
        }
    }

}
