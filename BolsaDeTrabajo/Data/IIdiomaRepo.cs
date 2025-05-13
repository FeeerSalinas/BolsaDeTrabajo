using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface IIdiomaRepo
    {
        Task<bool> CrearAsync(Idioma idioma, CancellationToken cancellationToken);
        Task<bool> EditarAsync(Idioma idioma, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int id, CancellationToken cancellationToken);
        Task<Idioma?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Idioma>> ObtenerTodosAsync(CancellationToken cancellationToken);
        Task<List<Idioma>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken);
    }
}
