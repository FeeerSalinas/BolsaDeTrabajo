using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class direccionQueries
    {
        public record ObtenerDireccionPorIdQuery(int IdUsuario) : IRequest<Direccion?>;

        public record ObtenerTodasDireccionesQuery() : IRequest<List<Direccion>>;

        public record ObtenerDireccionesPaginadasQuery(int Page, int PageSize) : IRequest<List<Direccion>>;
    }
}
