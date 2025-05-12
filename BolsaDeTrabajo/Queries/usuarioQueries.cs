using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class usuarioQueries
    {
        public record ObtenerUsuarioPorIdQuery(int IdUsuario) : IRequest<Usuario?>;
        public record ObtenerTodosUsuariosQuery() : IRequest<List<Usuario>>;
        public record ObtenerUsuariosPaginadosQuery(int Page, int PageSize) : IRequest<List<Usuario>>;

    }
}
