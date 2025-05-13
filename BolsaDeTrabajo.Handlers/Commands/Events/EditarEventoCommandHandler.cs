using BolsaDeTrabajo.Commands;
using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Handlers.Commands.Events
{
    public class EditarEventoCommandHandler : IRequestHandler<eventosCommands.EditarEventoCommand, bool>
    {
        private readonly IEventoRepo _repo;

        public EditarEventoCommandHandler(IEventoRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(eventosCommands.EditarEventoCommand request, CancellationToken cancellationToken)
        {
            var evento = new Evento(request.IdAspirante, request.NombreEvento, request.TipoEvento, request.Pais, request.Anfitrion, request.FechaEvento)
            {
                IdEvento = request.IdEvento
            };
            evento.Validate();
            return await _repo.EditarAsync(evento, cancellationToken);
        }
    }
}
