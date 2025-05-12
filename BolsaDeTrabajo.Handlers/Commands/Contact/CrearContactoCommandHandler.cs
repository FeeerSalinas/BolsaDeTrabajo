using BolsaDeTrabajo.Commands;
using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.cotactosCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Contact
{
    public class CrearContactoCommandHandler : IRequestHandler<CrearContactoCommand, bool>
    {
        private readonly IContactoRepo _repo;
        public CrearContactoCommandHandler(IContactoRepo repo) => _repo = repo;

        public async Task<bool> Handle(CrearContactoCommand request, CancellationToken cancellationToken)
        {
            var contacto = new Contacto(request.IdUsuario, request.TelefonoPersonal, request.TelefonoFijo);
            return await _repo.CrearAsync(contacto, cancellationToken);
        }
    }
}
