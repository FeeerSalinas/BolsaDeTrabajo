using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class aplicacionQueries
    {
        public record ObtenerAplicacionPorIdQuery(int IdAplicacion) : IRequest<AplicacionOferta?>;

        public record ObtenerTodasAplicacionesQuery : IRequest<List<AplicacionOferta>>;

        public record ObtenerAplicacionesPaginadasQuery(int Page, int PageSize) : IRequest<List<AplicacionOferta>>;

        public record ObtenerAplicacionesPorAspiranteQuery(int IdAspirante) : IRequest<List<AplicacionOferta>>;

        public record ObtenerAplicacionesPorOfertaQuery(int IdOferta) : IRequest<List<AplicacionOferta>>;
    }
}
