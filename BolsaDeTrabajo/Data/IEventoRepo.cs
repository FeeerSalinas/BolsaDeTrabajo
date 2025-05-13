using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface IEventoRepo
    {
        Task<bool> CrearAsync(Evento evento, CancellationToken cancellationToken);
        Task<bool> EditarAsync(Evento evento, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int idEvento, CancellationToken cancellationToken);
        Task<Evento?> ObtenerPorIdAsync(int idEvento, CancellationToken cancellationToken);
        Task<List<Evento>> ObtenerTodosAsync(CancellationToken cancellationToken);
        Task<List<Evento>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken);
    }
}
