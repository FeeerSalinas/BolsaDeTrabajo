using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface IDocumentoRepo
    {
        Task<bool> CrearAsync(DocumentosAspirante documento, CancellationToken cancellationToken);
        Task<bool> EditarAsync(DocumentosAspirante documento, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int idAspirante, CancellationToken cancellationToken);
        Task<DocumentosAspirante?> ObtenerPorIdAsync(int idAspirante, CancellationToken cancellationToken);
        Task<List<DocumentosAspirante>> ObtenerTodosAsync(CancellationToken cancellationToken);
        Task<List<DocumentosAspirante>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken);
    }
}
