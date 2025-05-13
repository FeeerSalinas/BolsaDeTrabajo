using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.logroQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Achievements
{
    public class ObtenerLogroPorIdHandler : IRequestHandler<ObtenerLogroPorIdQuery, Logro?>
    {
        private readonly ILogroRepo _repo;

        public ObtenerLogroPorIdHandler(ILogroRepo repo)
        {
            _repo = repo;
        }

        public async Task<Logro?> Handle(ObtenerLogroPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdLogro, cancellationToken);
        }
    }

}
