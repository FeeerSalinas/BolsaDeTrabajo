using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class RecomendacionRepo : IRecomendacionRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public RecomendacionRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearAsync(Recomendacion recomendacion, CancellationToken cancellationToken)
        {
            _context.Recomendaciones.Add(recomendacion);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EditarAsync(Recomendacion recomendacion, CancellationToken cancellationToken)
        {
            var existente = await _context.Recomendaciones.FindAsync(new object[] { recomendacion.IdRecomendacion }, cancellationToken);
            if (existente is null) return false;

            existente.NombreRecomendador = recomendacion.NombreRecomendador;
            existente.Relacion = recomendacion.Relacion;
            existente.Telefono = recomendacion.Telefono;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EliminarAsync(int idRecomendacion, CancellationToken cancellationToken)
        {
            var existente = await _context.Recomendaciones.FindAsync(new object[] { idRecomendacion }, cancellationToken);
            if (existente is null) return false;

            _context.Recomendaciones.Remove(existente);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<Recomendacion?> ObtenerPorIdAsync(int idRecomendacion, CancellationToken cancellationToken)
        {
            return await _context.Recomendaciones
                .Include(r => r.Aspirante)
                .ThenInclude(a => a.Usuario)
                .FirstOrDefaultAsync(r => r.IdRecomendacion == idRecomendacion, cancellationToken);
        }

        public async Task<List<Recomendacion>> ObtenerTodasAsync(CancellationToken cancellationToken)
        {
            return await _context.Recomendaciones
                .Include(r => r.Aspirante)
                .ThenInclude(a => a.Usuario)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Recomendacion>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Recomendaciones
                .Include(r => r.Aspirante)
                .ThenInclude(a => a.Usuario)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
    }
}
