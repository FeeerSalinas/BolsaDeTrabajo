using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class ExamenRepo : IExamenRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public ExamenRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearAsync(Examen examen, CancellationToken cancellationToken)
        {
            _context.Examenes.Add(examen);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EditarAsync(Examen examen, CancellationToken cancellationToken)
        {
            var existente = await _context.Examenes.FindAsync(new object[] { examen.IdExamen }, cancellationToken);
            if (existente is null) return false;

            existente.TipoExamen = examen.TipoExamen;
            existente.FechaRealizacion = examen.FechaRealizacion;
            existente.ResultadoNumerico = examen.ResultadoNumerico;
            existente.ResultadoCualitativo = examen.ResultadoCualitativo;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EliminarAsync(int idExamen, CancellationToken cancellationToken)
        {
            var existente = await _context.Examenes.FindAsync(new object[] { idExamen }, cancellationToken);
            if (existente is null) return false;

            _context.Examenes.Remove(existente);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<Examen?> ObtenerPorIdAsync(int idExamen, CancellationToken cancellationToken)
        {
            return await _context.Examenes
                .Include(e => e.Aspirante)
                .ThenInclude(a => a.Usuario)
                .FirstOrDefaultAsync(e => e.IdExamen == idExamen, cancellationToken);
        }

        public async Task<List<Examen>> ObtenerTodosAsync(CancellationToken cancellationToken)
        {
            return await _context.Examenes
                .Include(e => e.Aspirante)
                .ThenInclude(a => a.Usuario)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Examen>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Examenes
                .Include(e => e.Aspirante)
                .ThenInclude(a => a.Usuario)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
    }
}
