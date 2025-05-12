using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface IAspiranteRepo
    {
        Task<int> CrearAsync(Aspirante aspirante, CancellationToken cancellationToken);
        Task<bool> EditarAsync(Aspirante aspirante, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int idAspirante, CancellationToken cancellationToken);
        Task<Aspirante?> ObtenerPorIdAsync(int idAspirante, CancellationToken cancellationToken);
        Task<List<Aspirante>> ObtenerTodosAsync(CancellationToken cancellationToken);
        Task<List<Aspirante>> ObtenerPaginadosAsync(int pagina, int tamanoPagina, CancellationToken cancellationToken);
    }
}
