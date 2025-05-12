using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class aspiranteQueries
    {
        public record ObtenerAspirantePorIdQuery(int IdAspirante) : IRequest<Aspirante?>;

        public record ObtenerAspirantesQuery : IRequest<List<Aspirante>>;

        public record ObtenerAspirantesPaginadosQuery(int Pagina, int TamanoPagina) : IRequest<List<Aspirante>>;

    }
}
