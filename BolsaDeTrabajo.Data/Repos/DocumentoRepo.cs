using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class DocumentoRepo : IDocumentoRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public DocumentoRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearAsync(DocumentosAspirante documento, CancellationToken cancellationToken)
        {
            _context.DocumentosAspirantes.Add(documento);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EditarAsync(DocumentosAspirante documento, CancellationToken cancellationToken)
        {
            var existente = await _context.DocumentosAspirantes.FindAsync(new object[] { documento.IdAspirante }, cancellationToken);
            if (existente is null) return false;

            existente.TipoDocumento = documento.TipoDocumento;
            existente.NumeroDocumento = documento.NumeroDocumento;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EliminarAsync(int idAspirante, CancellationToken cancellationToken)
        {
            var existente = await _context.DocumentosAspirantes.FindAsync(new object[] { idAspirante }, cancellationToken);
            if (existente is null) return false;

            _context.DocumentosAspirantes.Remove(existente);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<DocumentosAspirante?> ObtenerPorIdAsync(int idAspirante, CancellationToken cancellationToken)
        {
            return await _context.DocumentosAspirantes
                .Include(d => d.Aspirante)
                .FirstOrDefaultAsync(d => d.IdAspirante == idAspirante, cancellationToken);
        }

        public async Task<List<DocumentosAspirante>> ObtenerTodosAsync(CancellationToken cancellationToken)
        {
            return await _context.DocumentosAspirantes
                .Include(d => d.Aspirante)
                    .ThenInclude(a => a.Usuario)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<DocumentosAspirante>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.DocumentosAspirantes
                 .Include(d => d.Aspirante)
                     .ThenInclude(a => a.Usuario)
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize)
                 .ToListAsync(cancellationToken);
        }
    }
}
