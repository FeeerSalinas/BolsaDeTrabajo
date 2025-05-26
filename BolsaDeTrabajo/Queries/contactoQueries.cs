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
        // ✅ QUERIES EXISTENTES (sin modificar)
        public record ObtenerContactoPorIdQuery(int IdUsuario) : IRequest<Contacto?>;
        public record ObtenerTodosContactosQuery() : IRequest<List<Contacto>>;
        public record ObtenerContactosPaginadosQuery(int Page, int PageSize) : IRequest<List<Contacto>>;

        // 🆕 NUEVA QUERY AGREGADA (aunque es similar a ObtenerContactoPorIdQuery)
        public record ObtenerContactoPorUsuarioQuery(int IdUsuario) : IRequest<Contacto?>;
    }
}