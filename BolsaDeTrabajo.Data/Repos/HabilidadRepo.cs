using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class HabilidadRepo : IHabilidadRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public HabilidadRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearAsync(Habilidad habilidad, CancellationToken cancellationToken)
        {
            _context.Habilidades.Add(habilidad);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EditarAsync(Habilidad habilidad, CancellationToken cancellationToken)
        {
            var existente = await _context.Habilidades.FindAsync(new object[] { habilidad.IdHabilidad }, cancellationToken);
            if (existente is null) return false;

            existente.NombreHabilidad = habilidad.NombreHabilidad;
            existente.NivelDominio = habilidad.NivelDominio;
            existente.Comentario = habilidad.Comentario;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EliminarAsync(int idHabilidad, CancellationToken cancellationToken)
        {
            var existente = await _context.Habilidades.FindAsync(new object[] { idHabilidad }, cancellationToken);
            if (existente is null) return false;

            _context.Habilidades.Remove(existente);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<Habilidad?> ObtenerPorIdAsync(int idHabilidad, CancellationToken cancellationToken)
        {
            return await _context.Habilidades
                .Include(h => h.Aspirante)
                .ThenInclude(a => a.Usuario)
                .FirstOrDefaultAsync(h => h.IdHabilidad == idHabilidad, cancellationToken);
        }

        public async Task<List<Habilidad>> ObtenerTodasAsync(CancellationToken cancellationToken)
        {
            return await _context.Habilidades
                .Include(h => h.Aspirante)
                .ThenInclude(a => a.Usuario)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Habilidad>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Habilidades
                .Include(h => h.Aspirante)
                .ThenInclude(a => a.Usuario)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
    }
}
