using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.direccionCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Address
{
    public class EditarDireccionCommandHandler : IRequestHandler<EditarDireccionCommand, bool>
    {
        private readonly IDireccionRepo _repo;

        public EditarDireccionCommandHandler(IDireccionRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EditarDireccionCommand request, CancellationToken cancellationToken)
        {
            var direccion = new Direccion(request.IdUsuario, request.Departamento, request.Municipio, request.DetalleDireccion);
            direccion.Validate();
            return await _repo.EditarAsync(direccion, cancellationToken);
        }
    }
}
