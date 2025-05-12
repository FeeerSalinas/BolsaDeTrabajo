using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface IContactoRepo
    {
        Task<bool> CrearAsync(Contacto contacto, CancellationToken cancellationToken);
        Task<bool> EditarAsync(Contacto contacto, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int idUsuario, CancellationToken cancellationToken);
        Task<Contacto?> ObtenerPorIdAsync(int idUsuario, CancellationToken cancellationToken);
        Task<List<Contacto>> ObtenerTodosAsync(CancellationToken cancellationToken);
        Task<List<Contacto>> ObtenerPaginadosAsync(int page, int pageSize, CancellationToken cancellationToken);
    }
}
