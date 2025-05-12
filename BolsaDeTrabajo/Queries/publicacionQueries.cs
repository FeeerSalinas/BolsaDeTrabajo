using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class publicacionQueries
    {
        public record ObtenerPublicacionPorIdQuery(int IdPublicacion) : IRequest<Publicacion?>;

        public record ObtenerTodasPublicacionesQuery() : IRequest<List<Publicacion>>;

        public record ObtenerPublicacionesPaginadasQuery(int Page, int PageSize) : IRequest<List<Publicacion>>;
    }
}
