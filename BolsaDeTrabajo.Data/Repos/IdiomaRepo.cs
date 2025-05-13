using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class IdiomaRepo : IIdiomaRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public IdiomaRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearAsync(Idioma idioma, CancellationToken cancellationToken)
        {
            _context.Idiomas.Add(idioma);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EditarAsync(Idioma idioma, CancellationToken cancellationToken)
        {
            var existente = await _context.Idiomas.FindAsync(new object[] { idioma.IdIdioma }, cancellationToken);
            if (existente is null) return false;

            existente.NombreIdioma = idioma.NombreIdioma;
            existente.NivelLectura = idioma.NivelLectura;
            existente.NivelEscritura = idioma.NivelEscritura;
            existente.NivelConversacion = idioma.NivelConversacion;
            existente.NivelEscucha = idioma.NivelEscucha;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EliminarAsync(int id, CancellationToken cancellationToken)
        {
            var existente = await _context.Idiomas.FindAsync(new object[] { id }, cancellationToken);
            if (existente is null) return false;

            _context.Idiomas.Remove(existente);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<Idioma?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Idiomas
                .Include(i => i.Aspirante)
                .ThenInclude(a => a!.Usuario)
                .FirstOrDefaultAsync(i => i.IdIdioma == id, cancellationToken);
        }

        public async Task<List<Idioma>> ObtenerTodosAsync(CancellationToken cancellationToken)
        {
            return await _context.Idiomas
                .Include(i => i.Aspirante)
                .ThenInclude(a => a!.Usuario)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Idioma>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Idiomas
                .Include(i => i.Aspirante)
                .ThenInclude(a => a!.Usuario)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
    }
}
