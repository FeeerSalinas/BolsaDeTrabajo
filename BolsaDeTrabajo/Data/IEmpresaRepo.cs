using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface IEmpresaRepo
    {
        Task<int> CrearAsync(Empresa empresa, CancellationToken cancellationToken);
        Task<bool> EditarAsync(Empresa empresa, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int idEmpresa, CancellationToken cancellationToken);
        Task<Empresa?> ObtenerPorIdAsync(int idEmpresa, CancellationToken cancellationToken);
        Task<List<Empresa>> ObtenerTodasAsync(CancellationToken cancellationToken);
        Task<List<Empresa>> ObtenerPaginadasAsync(int pagina, int tamañoPagina, CancellationToken cancellationToken);
    }
}
