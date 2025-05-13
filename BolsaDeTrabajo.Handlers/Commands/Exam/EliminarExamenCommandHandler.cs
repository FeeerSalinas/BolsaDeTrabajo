using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.examenCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Exam
{
    public class EliminarExamenCommandHandler : IRequestHandler<EliminarExamenCommand, bool>
    {
        private readonly IExamenRepo _repo;

        public EliminarExamenCommandHandler(IExamenRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EliminarExamenCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdExamen, cancellationToken);
        }
    }
}
