using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class UsuarioRepo : IUsuarioRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public UsuarioRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<int> CrearAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            usuario.Validate();
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync(cancellationToken);
            return usuario.IdUsuario;
        }

        public async Task<bool> EditarAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            var existente = await _context.Usuarios.FindAsync(new object[] { usuario.IdUsuario }, cancellationToken);
            if (existente == null) return false;

            existente.Correo = usuario.Correo;
            existente.Clave = usuario.Clave;
            existente.Rol = usuario.Rol;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> EliminarAsync(int idUsuario, CancellationToken cancellationToken)
        {
            var usuario = await _context.Usuarios.FindAsync(new object[] { idUsuario }, cancellationToken);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<Usuario>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Usuarios
                 .AsNoTracking()
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize)
                 .ToListAsync(cancellationToken);
        }

        public async Task<Usuario?> ObtenerPorCorreoAsync(string correo, CancellationToken cancellationToken)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == correo, cancellationToken);
        }

        public async Task<Usuario?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.IdUsuario == id, cancellationToken);
        }

        public async Task<List<Usuario>> ObtenerTodosAsync(CancellationToken cancellationToken)
        {
            return await _context.Usuarios
                 .AsNoTracking()
                 .ToListAsync(cancellationToken);
        }
    }
}
