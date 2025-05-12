using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface IHabilidadRepo
    {
        Task<bool> CrearAsync(Habilidad habilidad, CancellationToken cancellationToken);
        Task<bool> EditarAsync(Habilidad habilidad, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int idHabilidad, CancellationToken cancellationToken);
        Task<Habilidad?> ObtenerPorIdAsync(int idHabilidad, CancellationToken cancellationToken);
        Task<List<Habilidad>> ObtenerTodasAsync(CancellationToken cancellationToken);
        Task<List<Habilidad>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken);
    }
}
