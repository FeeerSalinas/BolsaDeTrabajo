using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.experienciaCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Experience
{
    public class EliminarExperienciaCommandHandler : IRequestHandler<EliminarExperienciaCommand, bool>
    {
        private readonly IExperienciaRepo _repo;

        public EliminarExperienciaCommandHandler(IExperienciaRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EliminarExperienciaCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdExperiencia, cancellationToken);
        }
    }
}
