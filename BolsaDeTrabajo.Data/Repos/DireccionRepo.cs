using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class DireccionRepo : IDireccionRepo
    {

        private readonly BolsaDeTrabajoContext _context;

        public DireccionRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearAsync(Direccion direccion, CancellationToken cancellationToken)
        {
            _context.Direcciones.Add(direccion);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EditarAsync(Direccion direccion, CancellationToken cancellationToken)
        {
            var existente = await _context.Direcciones.FindAsync(new object[] { direccion.IdUsuario }, cancellationToken);
            if (existente is null) return false;

            existente.Departamento = direccion.Departamento;
            existente.Municipio = direccion.Municipio;
            existente.DetalleDireccion = direccion.DetalleDireccion;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EliminarAsync(int idUsuario, CancellationToken cancellationToken)
        {
            var direccion = await _context.Direcciones.FindAsync(new object[] { idUsuario }, cancellationToken);
            if (direccion is null) return false;

            _context.Direcciones.Remove(direccion);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<List<Direccion>> ObtenerPaginadasAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Direcciones
                .Include(d => d.Usuario)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<Direccion?> ObtenerPorIdAsync(int idUsuario, CancellationToken cancellationToken)
        {
            return await _context.Direcciones
               .Include(d => d.Usuario)
               .FirstOrDefaultAsync(d => d.IdUsuario == idUsuario, cancellationToken);
        }

        public async Task<List<Direccion>> ObtenerTodasAsync(CancellationToken cancellationToken)
        {
            return await _context.Direcciones.Include(d => d.Usuario).ToListAsync(cancellationToken);
        }
    }
}
