using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface IExamenRepo
    {
        Task<bool> CrearAsync(Examen examen, CancellationToken cancellationToken);
        Task<bool> EditarAsync(Examen examen, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int idExamen, CancellationToken cancellationToken);
        Task<Examen?> ObtenerPorIdAsync(int idExamen, CancellationToken cancellationToken);
        Task<List<Examen>> ObtenerTodosAsync(CancellationToken cancellationToken);
        Task<List<Examen>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken);
    }
}
