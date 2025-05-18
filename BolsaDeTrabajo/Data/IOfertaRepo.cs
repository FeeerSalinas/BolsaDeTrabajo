using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface IOfertaRepo
    {
        Task<bool> CrearAsync(OfertaLaboral oferta, CancellationToken cancellationToken);
        Task<bool> EditarAsync(OfertaLaboral oferta, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int idOferta, CancellationToken cancellationToken);

        Task<OfertaLaboral?> ObtenerPorIdAsync(int idOferta, CancellationToken cancellationToken);
        Task<List<OfertaLaboral>> ObtenerTodasAsync(CancellationToken cancellationToken);
        Task<List<OfertaLaboral>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken);
        Task<List<OfertaLaboral>> ObtenerOfertaPorPerfil(string perfilAcademico, CancellationToken cancellationToken);
    }
}
