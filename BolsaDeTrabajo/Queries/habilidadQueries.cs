using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class habilidadQueries
    {
        public record ObtenerHabilidadPorIdQuery(int IdHabilidad) : IRequest<Habilidad?>;

        public record ObtenerTodasHabilidadesQuery() : IRequest<List<Habilidad>>;

        public record ObtenerHabilidadesPaginadasQuery(int Page, int PageSize) : IRequest<List<Habilidad>>;
    }
}
