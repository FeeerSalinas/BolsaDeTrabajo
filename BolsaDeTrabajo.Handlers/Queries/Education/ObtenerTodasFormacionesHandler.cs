using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.formacionQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Education
{
    public class ObtenerTodasFormacionesHandler : IRequestHandler<ObtenerTodasFormacionesQuery, List<FormacionAcademica>>
    {
        private readonly IFormacionRepo _repo;

        public ObtenerTodasFormacionesHandler(IFormacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<FormacionAcademica>> Handle(ObtenerTodasFormacionesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerTodasAsync(cancellationToken);
        }
    }
}
