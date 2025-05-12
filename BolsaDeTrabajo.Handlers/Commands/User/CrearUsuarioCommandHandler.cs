using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Data.Repos;
using BolsaDeTrabajo.Models;
using BolsaDeTrabajo.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.usuarioCommands;

namespace BolsaDeTrabajo.Handlers.Commands.User
{
    public class CrearUsuarioCommandHandler : IRequestHandler<CrearUsuarioCommand, int>
    {

        private readonly IUsuarioRepo _repo;

        public CrearUsuarioCommandHandler(IUsuarioRepo repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
        {
            var nuevoUsuario = new Usuario(request.Correo, PasswordHasher.Hash(request.Clave), request.Rol);
            return await _repo.CrearAsync(nuevoUsuario, cancellationToken);
        }
    }
}
