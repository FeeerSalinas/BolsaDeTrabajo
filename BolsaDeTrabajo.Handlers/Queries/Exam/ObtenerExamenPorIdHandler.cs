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
    public class ObtenerExamenPorIdHandler : IRequestHandler<ObtenerExamenPorIdQuery, Examen?>
    {
        private readonly IExamenRepo _repo;

        public ObtenerExamenPorIdHandler(IExamenRepo repo)
        {
            _repo = repo;
        }

        public async Task<Examen?> Handle(ObtenerExamenPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdExamen, cancellationToken);
        }
    }
}
