using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface ILogroRepo
    {
        Task<bool> CrearAsync(Logro logro, CancellationToken cancellationToken);
        Task<bool> EditarAsync(Logro logro, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int idLogro, CancellationToken cancellationToken);
        Task<Logro?> ObtenerPorIdAsync(int idLogro, CancellationToken cancellationToken);
        Task<List<Logro>> ObtenerTodasAsync(CancellationToken cancellationToken);
        Task<List<Logro>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken);
    }
}
