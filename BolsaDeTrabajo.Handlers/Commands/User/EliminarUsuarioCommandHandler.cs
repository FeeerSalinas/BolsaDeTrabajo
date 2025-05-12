using BolsaDeTrabajo.Data;
using MediatR;
using static BolsaDeTrabajo.Commands.usuarioCommands;

namespace BolsaDeTrabajo.Handlers.Commands.User
{
    public class EliminarUsuarioCommandHandler : IRequestHandler<EliminarUsuarioCommand, bool>
    {
        private readonly IUsuarioRepo _repo;

        public EliminarUsuarioCommandHandler(IUsuarioRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EliminarUsuarioCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdUsuario, cancellationToken);
        }
    }
}
