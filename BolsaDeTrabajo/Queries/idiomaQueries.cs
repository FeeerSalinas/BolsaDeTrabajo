using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class idiomaQueries
    {
        public record ObtenerIdiomaPorIdQuery(int IdIdioma) : IRequest<Idioma?>;

        public record ObtenerTodosIdiomasQuery() : IRequest<List<Idioma>>;

        public record ObtenerIdiomasPaginadosQuery(int Page, int PageSize) : IRequest<List<Idioma>>;
    }
}
