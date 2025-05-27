using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class contactoQueries
    {
        public record ObtenerContactoPorIdQuery(int IdUsuario) : IRequest<Contacto?>;
        public record ObtenerTodosContactosQuery() : IRequest<List<Contacto>>;
        public record ObtenerContactosPaginadosQuery(int Page, int PageSize) : IRequest<List<Contacto>>;

        public record ObtenerContactoPorUsuarioQuery(int IdUsuario) : IRequest<Contacto?>;
    }
}