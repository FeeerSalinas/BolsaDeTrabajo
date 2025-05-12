using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.habilidadCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Skills
{
    public class EliminarHabilidadCommandHandler : IRequestHandler<EliminarHabilidadCommand, bool>
    {
        private readonly IHabilidadRepo _repo;

        public EliminarHabilidadCommandHandler(IHabilidadRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EliminarHabilidadCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdHabilidad, cancellationToken);
        }
    }
}

