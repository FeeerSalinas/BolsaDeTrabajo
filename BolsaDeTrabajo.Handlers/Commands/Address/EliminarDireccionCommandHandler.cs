using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.direccionCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Address
{
    public class EliminarDireccionCommandHandler : IRequestHandler<EliminarDireccionCommand, bool>
    {
        private readonly IDireccionRepo _repo;

        public EliminarDireccionCommandHandler(IDireccionRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EliminarDireccionCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdUsuario, cancellationToken);
        }
    }
}
