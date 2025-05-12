using MediatR;


namespace BolsaDeTrabajo.Commands
{
    public class usuarioCommands
    {
        public record CrearUsuarioCommand(string Correo, string Clave, string Rol) : IRequest<int>;

        public record EditarUsuarioCommand(int IdUsuario, string Correo, string Clave, string Rol) : IRequest<bool>;

        public record EliminarUsuarioCommand(int IdUsuario) : IRequest<bool>;

        public record LoginUsuarioCommand(string Correo, string Clave) : IRequest<string?>;
    }
}
