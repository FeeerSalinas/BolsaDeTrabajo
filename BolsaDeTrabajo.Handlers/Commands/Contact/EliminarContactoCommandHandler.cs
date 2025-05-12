using BolsaDeTrabajo.Commands;
using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.cotactosCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Contact
{
    public class EliminarContactoCommandHandler : IRequestHandler<EliminarContactoCommand, bool>
    {
        private readonly IContactoRepo _repo;
        public EliminarContactoCommandHandler(IContactoRepo repo) => _repo = repo;

        public async Task<bool> Handle(EliminarContactoCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdUsuario, cancellationToken);
        }
    }
}
