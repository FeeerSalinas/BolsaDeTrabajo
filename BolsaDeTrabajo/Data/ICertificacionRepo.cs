using BolsaDeTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface ICertificacionRepo
    {
        Task<bool> CrearAsync(Certificacion certificacion, CancellationToken cancellationToken);
        Task<bool> EditarAsync(Certificacion certificacion, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int idCertificacion, CancellationToken cancellationToken);
        Task<Certificacion?> ObtenerPorIdAsync(int idCertificacion, CancellationToken cancellationToken);
        Task<List<Certificacion>> ObtenerTodasAsync(CancellationToken cancellationToken);
        Task<List<Certificacion>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken);
    }
}
