using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface IRecomendacionRepo
    {
        Task<bool> CrearAsync(Recomendacion recomendacion, CancellationToken cancellationToken);
        Task<bool> EditarAsync(Recomendacion recomendacion, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int idRecomendacion, CancellationToken cancellationToken);
        Task<Recomendacion?> ObtenerPorIdAsync(int idRecomendacion, CancellationToken cancellationToken);
        Task<List<Recomendacion>> ObtenerTodasAsync(CancellationToken cancellationToken);
        Task<List<Recomendacion>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken);
    }
}

