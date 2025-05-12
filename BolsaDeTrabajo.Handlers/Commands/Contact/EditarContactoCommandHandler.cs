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
    public class EditarContactoCommandHandler : IRequestHandler<EditarContactoCommand, bool>
    {
        private readonly IContactoRepo _repo;
        public EditarContactoCommandHandler(IContactoRepo repo) => _repo = repo;

        public async Task<bool> Handle(EditarContactoCommand request, CancellationToken cancellationToken)
        {
            var contacto = new Contacto(request.IdUsuario, request.TelefonoPersonal, request.TelefonoFijo);
            return await _repo.EditarAsync(contacto, cancellationToken);
        }
    }
}
