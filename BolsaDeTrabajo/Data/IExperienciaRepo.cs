using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface IExperienciaRepo
    {
        Task<bool> CrearAsync(ExperienciaLaboral experiencia, CancellationToken cancellationToken);
        Task<bool> EditarAsync(ExperienciaLaboral experiencia, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int idExperiencia, CancellationToken cancellationToken);
        Task<ExperienciaLaboral?> ObtenerPorIdAsync(int idExperiencia, CancellationToken cancellationToken);
        Task<List<ExperienciaLaboral>> ObtenerTodasAsync(CancellationToken cancellationToken);
        Task<List<ExperienciaLaboral>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken);
    }
}
