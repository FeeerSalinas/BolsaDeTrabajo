using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class PublicacionRepo : IPublicacionRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public PublicacionRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearAsync(Publicacion publicacion, CancellationToken cancellationToken)
        {
            _context.Publicaciones.Add(publicacion);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EditarAsync(Publicacion publicacion, CancellationToken cancellationToken)
        {
            var existente = await _context.Publicaciones.FindAsync(new object[] { publicacion.IdPublicacion }, cancellationToken);
            if (existente is null) return false;

            existente.TipoPublicacion = publicacion.TipoPublicacion;
            existente.Titulo = publicacion.Titulo;
            existente.LugarPublicacion = publicacion.LugarPublicacion;
            existente.FechaPublicacion = publicacion.FechaPublicacion;
            existente.Isbn = publicacion.Isbn;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EliminarAsync(int idPublicacion, CancellationToken cancellationToken)
        {
            var existente = await _context.Publicaciones.FindAsync(new object[] { idPublicacion }, cancellationToken);
            if (existente is null) return false;

            _context.Publicaciones.Remove(existente);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<Publicacion?> ObtenerPorIdAsync(int idPublicacion, CancellationToken cancellationToken)
        {
            return await _context.Publicaciones
                .Include(p => p.Aspirante)
                .ThenInclude(a => a.Usuario)
                .FirstOrDefaultAsync(p => p.IdPublicacion == idPublicacion, cancellationToken);
        }

        public async Task<List<Publicacion>> ObtenerTodasAsync(CancellationToken cancellationToken)
        {
            return await _context.Publicaciones
                .Include(p => p.Aspirante)
                .ThenInclude(a => a.Usuario)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Publicacion>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Publicaciones
                .Include(p => p.Aspirante)
                .ThenInclude(a => a.Usuario)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
    }
}
