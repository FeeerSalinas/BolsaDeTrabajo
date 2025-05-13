using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class logroQueries
    {
        public record ObtenerLogroPorIdQuery(int IdLogro) : IRequest<Logro?>;
        public record ObtenerTodosLogrosQuery : IRequest<List<Logro>>;
        public record ObtenerLogrosPaginadosQuery(int Page, int PageSize) : IRequest<List<Logro>>;
    }
}
