using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.examenQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Exam
{
    public class ObtenerExamenesPaginadosHandler : IRequestHandler<ObtenerExamenesPaginadosQuery, List<Examen>>
    {
        private readonly IExamenRepo _repo;

        public ObtenerExamenesPaginadosHandler(IExamenRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Examen>> Handle(ObtenerExamenesPaginadosQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPaginadoAsync(request.Page, request.PageSize, cancellationToken);
        }
    }
}
