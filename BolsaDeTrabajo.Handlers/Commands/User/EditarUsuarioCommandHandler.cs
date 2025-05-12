using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Security;
using MediatR;
using static BolsaDeTrabajo.Commands.usuarioCommands;

namespace BolsaDeTrabajo.Handlers.Commands.User
{
    public class EditarUsuarioCommandHandler : IRequestHandler<EditarUsuarioCommand, bool>
    {
        private readonly IUsuarioRepo _repo;

        public EditarUsuarioCommandHandler(IUsuarioRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EditarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Models.Usuario(
                request.Correo,
                PasswordHasher.Hash(request.Clave),
                request.Rol
            )
            {
                IdUsuario = request.IdUsuario
            };

            return await _repo.EditarAsync(usuario, cancellationToken);
        }
    }
}
