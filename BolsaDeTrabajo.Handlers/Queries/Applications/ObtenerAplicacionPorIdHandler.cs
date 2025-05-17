using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.aplicacionQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Applications
{
    public class ObtenerAplicacionPorIdHandler : IRequestHandler<ObtenerAplicacionPorIdQuery, AplicacionOferta?>
    {
        private readonly IAplicacionOfertaRepo _repo;

        public ObtenerAplicacionPorIdHandler(IAplicacionOfertaRepo repo)
        {
            _repo = repo;
        }

        public async Task<AplicacionOferta?> Handle(ObtenerAplicacionPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdAplicacion, cancellationToken);
        }
    }
}
