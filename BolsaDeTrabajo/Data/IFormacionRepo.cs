using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface IFormacionRepo
    {
        Task<bool> CrearAsync(FormacionAcademica formacion, CancellationToken cancellationToken);
        Task<bool> EditarAsync(FormacionAcademica formacion, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int idFormacion, CancellationToken cancellationToken);
        Task<FormacionAcademica?> ObtenerPorIdAsync(int idFormacion, CancellationToken cancellationToken);
        Task<List<FormacionAcademica>> ObtenerTodasAsync(CancellationToken cancellationToken);
        Task<List<FormacionAcademica>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken);
    }
}
