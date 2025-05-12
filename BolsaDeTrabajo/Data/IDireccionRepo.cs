using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface IDireccionRepo
    {
        Task<bool> CrearAsync(Direccion direccion, CancellationToken cancellationToken);

        Task<bool> EditarAsync(Direccion direccion, CancellationToken cancellationToken);

        Task<bool> EliminarAsync(int idUsuario, CancellationToken cancellationToken);

        Task<Direccion?> ObtenerPorIdAsync(int idUsuario, CancellationToken cancellationToken);

        Task<List<Direccion>> ObtenerTodasAsync(CancellationToken cancellationToken);

        Task<List<Direccion>> ObtenerPaginadasAsync(int page, int pageSize, CancellationToken cancellationToken);
    }
}

