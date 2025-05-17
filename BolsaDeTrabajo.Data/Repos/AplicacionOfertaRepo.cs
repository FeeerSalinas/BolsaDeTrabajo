using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class AplicacionOfertaRepo : IAplicacionOfertaRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public AplicacionOfertaRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearAsync(AplicacionOferta aplicacion, CancellationToken cancellationToken)
        {
            _context.AplicacionesOferta.Add(aplicacion);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EditarAsync(AplicacionOferta aplicacion, CancellationToken cancellationToken)
        {
            var existente = await _context.AplicacionesOferta.FindAsync(new object[] { aplicacion.IdAplicacion }, cancellationToken);
            if (existente is null) return false;

            existente.IdOferta = aplicacion.IdOferta;
            existente.IdAspirante = aplicacion.IdAspirante;
            existente.FechaAplicacion = aplicacion.FechaAplicacion;
            existente.Estado = aplicacion.Estado;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EliminarAsync(int idAplicacion, CancellationToken cancellationToken)
        {
            var existente = await _context.AplicacionesOferta.FindAsync(new object[] { idAplicacion }, cancellationToken);
            if (existente is null) return false;

            _context.AplicacionesOferta.Remove(existente);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<AplicacionOferta?> ObtenerPorIdAsync(int idAplicacion, CancellationToken cancellationToken)
        {
            return await _context.AplicacionesOferta
                .Include(a => a.Aspirante)
                    .ThenInclude(a => a.Usuario)
                .Include(a => a.Oferta)
                    .ThenInclude(o => o.Empresa)
                        .ThenInclude(e => e.Usuario)
                .FirstOrDefaultAsync(a => a.IdAplicacion == idAplicacion, cancellationToken);
        }

        public async Task<List<AplicacionOferta>> ObtenerTodasAsync(CancellationToken cancellationToken)
        {
            return await _context.AplicacionesOferta
                .Include(a => a.Aspirante)
                    .ThenInclude(a => a.Usuario)
                .Include(a => a.Oferta)
                    .ThenInclude(o => o.Empresa)
                        .ThenInclude(e => e.Usuario)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<AplicacionOferta>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.AplicacionesOferta
                .Include(a => a.Aspirante)
                    .ThenInclude(a => a.Usuario)
                .Include(a => a.Oferta)
                    .ThenInclude(o => o.Empresa)
                        .ThenInclude(e => e.Usuario)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<AplicacionOferta>> ObtenerPorAspiranteAsync(int idAspirante, CancellationToken cancellationToken)
        {
            return await _context.AplicacionesOferta
                .Where(a => a.IdAspirante == idAspirante)
                .Include(a => a.Oferta)
                    .ThenInclude(o => o.Empresa)
                        .ThenInclude(e => e.Usuario)
                .Include(a => a.Aspirante)
                    .ThenInclude(a => a.Usuario)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<AplicacionOferta>> ObtenerPorOfertaAsync(int idOferta, CancellationToken cancellationToken)
        {
            return await _context.AplicacionesOferta
                .Where(a => a.IdOferta == idOferta)
                .Include(a => a.Aspirante)
                    .ThenInclude(a => a.Usuario)
                .Include(a => a.Oferta)
                    .ThenInclude(o => o.Empresa)
                        .ThenInclude(e => e.Usuario)
                .ToListAsync(cancellationToken);
        }
    }
}
