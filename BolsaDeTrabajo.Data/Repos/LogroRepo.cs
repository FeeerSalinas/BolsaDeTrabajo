using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class LogroRepo : ILogroRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public LogroRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearAsync(Logro logro, CancellationToken cancellationToken)
        {
            _context.Logros.Add(logro);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EditarAsync(Logro logro, CancellationToken cancellationToken)
        {
            var existente = await _context.Logros.FindAsync(new object[] { logro.IdLogro }, cancellationToken);
            if (existente is null) return false;

            existente.DescripcionLogro = logro.DescripcionLogro;
            existente.FechaLogro = logro.FechaLogro;
            existente.TipoLogro = logro.TipoLogro;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EliminarAsync(int idLogro, CancellationToken cancellationToken)
        {
            var existente = await _context.Logros.FindAsync(new object[] { idLogro }, cancellationToken);
            if (existente is null) return false;

            _context.Logros.Remove(existente);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<Logro?> ObtenerPorIdAsync(int idLogro, CancellationToken cancellationToken)
        {
            return await _context.Logros
                .Include(l => l.Aspirante)
                .ThenInclude(a => a.Usuario)
                .FirstOrDefaultAsync(l => l.IdLogro == idLogro, cancellationToken);
        }

        public async Task<List<Logro>> ObtenerTodasAsync(CancellationToken cancellationToken)
        {
            return await _context.Logros
                .Include(l => l.Aspirante)
                .ThenInclude(a => a.Usuario)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Logro>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Logros
                .Include(l => l.Aspirante)
                .ThenInclude(a => a.Usuario)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
    }
}
