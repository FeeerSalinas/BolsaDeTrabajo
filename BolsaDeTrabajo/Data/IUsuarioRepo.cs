using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface IUsuarioRepo
    {
        Task<int> CrearAsync(Usuario usuario, CancellationToken cancellationToken);
        Task<bool> EditarAsync(Usuario usuario, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int idUsuario, CancellationToken cancellationToken);
        Task<Usuario?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Usuario>> ObtenerTodosAsync(CancellationToken cancellationToken);
        Task<List<Usuario>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken);
        Task<Usuario?> ObtenerPorCorreoAsync(string correo, CancellationToken cancellationToken);

    }
}
