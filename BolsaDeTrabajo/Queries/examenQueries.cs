using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class examenQueries
    {
        public record ObtenerExamenPorIdQuery(int IdExamen) : IRequest<Examen?>;

        public record ObtenerTodosExamenesQuery : IRequest<List<Examen>>;

        public record ObtenerExamenesPaginadosQuery(int Page, int PageSize) : IRequest<List<Examen>>;
    }
}
