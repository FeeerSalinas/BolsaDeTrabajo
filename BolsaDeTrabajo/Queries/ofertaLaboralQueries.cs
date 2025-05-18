using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class ofertaLaboralQueries
    {
        public record ObtenerOfertaPorIdQuery(int IdOferta) : IRequest<OfertaLaboral?>;

        public record ObtenerTodasOfertasQuery() : IRequest<List<OfertaLaboral>>;

        public record ObtenerOfertasPaginadasQuery(int Page, int PageSize) : IRequest<List<OfertaLaboral>>;

        public record ObtenerOfertaPorPerfilAcademico(string perfilAcademico) : IRequest<List<OfertaLaboral>>;
    }
}
