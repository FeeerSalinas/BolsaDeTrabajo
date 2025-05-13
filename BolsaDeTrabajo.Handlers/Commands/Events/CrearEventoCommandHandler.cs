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
    public class CrearEventoCommandHandler : IRequestHandler<eventosCommands.CrearEventoCommand, bool>
    {
        private readonly IEventoRepo _repo;

        public CrearEventoCommandHandler(IEventoRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(eventosCommands.CrearEventoCommand request, CancellationToken cancellationToken)
        {
            var evento = new Evento(request.IdAspirante, request.NombreEvento, request.TipoEvento, request.Pais, request.Anfitrion, request.FechaEvento);
            evento.Validate();
            return await _repo.CrearAsync(evento, cancellationToken);
        }
    }
}
