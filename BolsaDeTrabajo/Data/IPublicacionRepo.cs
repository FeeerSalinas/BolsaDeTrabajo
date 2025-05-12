using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface IPublicacionRepo
    {
        Task<bool> CrearAsync(Publicacion publicacion, CancellationToken cancellationToken);
        Task<bool> EditarAsync(Publicacion publicacion, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int idPublicacion, CancellationToken cancellationToken);
        Task<Publicacion?> ObtenerPorIdAsync(int idPublicacion, CancellationToken cancellationToken);
        Task<List<Publicacion>> ObtenerTodasAsync(CancellationToken cancellationToken);
        Task<List<Publicacion>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken);
    }
}
