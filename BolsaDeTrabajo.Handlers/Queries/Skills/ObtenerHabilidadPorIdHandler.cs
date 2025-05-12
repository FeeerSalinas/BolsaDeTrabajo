using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.habilidadQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Skills
{
    public class ObtenerHabilidadPorIdHandler : IRequestHandler<ObtenerHabilidadPorIdQuery, Habilidad?>
    {
        private readonly IHabilidadRepo _repo;

        public ObtenerHabilidadPorIdHandler(IHabilidadRepo repo)
        {
            _repo = repo;
        }

        public async Task<Habilidad?> Handle(ObtenerHabilidadPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdHabilidad, cancellationToken);
        }
    }
}
