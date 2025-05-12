using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class recomendacionQueries
    {
        public record ObtenerRecomendacionPorIdQuery(int IdRecomendacion) : IRequest<Recomendacion?>;
        public record ObtenerTodasRecomendacionesQuery() : IRequest<List<Recomendacion>>;
        public record ObtenerRecomendacionesPaginadasQuery(int Page, int PageSize) : IRequest<List<Recomendacion>>;
    }
}
