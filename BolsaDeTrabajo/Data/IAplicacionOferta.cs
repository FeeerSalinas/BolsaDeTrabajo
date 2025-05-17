using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data
{
    public interface IAplicacionOfertaRepo
    {
        Task<bool> CrearAsync(AplicacionOferta aplicacion, CancellationToken cancellationToken);
        Task<bool> EditarAsync(AplicacionOferta aplicacion, CancellationToken cancellationToken);
        Task<bool> EliminarAsync(int idAplicacion, CancellationToken cancellationToken);

        Task<AplicacionOferta?> ObtenerPorIdAsync(int idAplicacion, CancellationToken cancellationToken);
        Task<List<AplicacionOferta>> ObtenerTodasAsync(CancellationToken cancellationToken);
        Task<List<AplicacionOferta>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken);

        Task<List<AplicacionOferta>> ObtenerPorAspiranteAsync(int idAspirante, CancellationToken cancellationToken);
        Task<List<AplicacionOferta>> ObtenerPorOfertaAsync(int idOferta, CancellationToken cancellationToken);
    }
}
