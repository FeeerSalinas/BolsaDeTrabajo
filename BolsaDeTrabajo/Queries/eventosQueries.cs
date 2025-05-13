using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class eventosQueries
    {
        public record ObtenerEventoPorIdQuery(int IdEvento) : IRequest<Evento?>;

        public record ObtenerTodosEventosQuery() : IRequest<List<Evento>>;

        public record ObtenerEventosPaginadosQuery(int Page, int PageSize) : IRequest<List<Evento>>;
    }
}
