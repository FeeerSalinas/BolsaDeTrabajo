using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.experienciaQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Experience
{
    public class ObtenerExperienciaPorIdHandler : IRequestHandler<ObtenerExperienciaPorIdQuery, ExperienciaLaboral?>
    {
        private readonly IExperienciaRepo _repo;

        public ObtenerExperienciaPorIdHandler(IExperienciaRepo repo)
        {
            _repo = repo;
        }

        public async Task<ExperienciaLaboral?> Handle(ObtenerExperienciaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdExperiencia, cancellationToken);
        }
    }
}
