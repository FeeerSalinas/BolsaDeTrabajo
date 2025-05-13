using BolsaDeTrabajo.Commands;
using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Handlers.Commands.Events
{
    public class EliminarEventoCommandHandler : IRequestHandler<eventosCommands.EliminarEventoCommand, bool>
    {
        private readonly IEventoRepo _repo;

        public EliminarEventoCommandHandler(IEventoRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(eventosCommands.EliminarEventoCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdEvento, cancellationToken);
        }
    }
}
