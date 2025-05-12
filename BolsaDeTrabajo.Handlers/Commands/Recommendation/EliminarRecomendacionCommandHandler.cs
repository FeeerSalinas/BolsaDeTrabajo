using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.habilidadCommands;
using static BolsaDeTrabajo.Commands.recomendacionCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Recommendation
{
    public class EliminarRecomendacionCommandHandler : IRequestHandler<EliminarRecomendacionCommand, bool>
    {
        private readonly IRecomendacionRepo _repo;

        public EliminarRecomendacionCommandHandler(IRecomendacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EliminarRecomendacionCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdRecomendacion, cancellationToken);
        }
    }
}
