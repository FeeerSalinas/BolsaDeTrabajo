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
    public class CrearDireccionCommandHandler : IRequestHandler<CrearDireccionCommand, bool>
    {
        private readonly IDireccionRepo _repo;

        public CrearDireccionCommandHandler(IDireccionRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(CrearDireccionCommand request, CancellationToken cancellationToken)
        {
            var direccion = new Direccion(request.IdUsuario, request.Departamento, request.Municipio, request.DetalleDireccion);
            direccion.Validate();
            return await _repo.CrearAsync(direccion, cancellationToken);
        }
    }
}
