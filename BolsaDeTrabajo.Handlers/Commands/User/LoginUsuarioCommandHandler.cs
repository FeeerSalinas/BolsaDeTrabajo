using BolsaDeTrabajo.Data;
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
    public class LoginUsuarioCommandHandler : IRequestHandler<LoginUsuarioCommand, string?>
    {
        private readonly IUsuarioRepo _repo;
        private readonly JwtTokenGenerator _jwt;

        public LoginUsuarioCommandHandler(IUsuarioRepo repo, JwtTokenGenerator jwt)
        {
            _repo = repo;
            _jwt = jwt;
        }

        public async Task<string?> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repo.ObtenerPorCorreoAsync(request.Correo, cancellationToken);
            if (usuario is null) return null;

            if (!PasswordHasher.Verify(request.Clave, usuario.Clave)) return null;

            return _jwt.GenerateToken(usuario.IdUsuario, usuario.Rol);
        }
    }
}
