using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class ContactoRepo : IContactoRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public ContactoRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearAsync(Contacto contacto, CancellationToken cancellationToken)
        {
            contacto.Validate();
            await _context.Contactos.AddAsync(contacto, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EditarAsync(Contacto contacto, CancellationToken cancellationToken)
        {
            var existente = await _context.Contactos.FindAsync(new object[] { contacto.IdUsuario }, cancellationToken);
            if (existente is null) return false;
            existente.TelefonoPersonal = contacto.TelefonoPersonal;
            existente.TelefonoFijo = contacto.TelefonoFijo;
            existente.RedesSociales = contacto.RedesSociales;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EliminarAsync(int idUsuario, CancellationToken cancellationToken)
        {
            var contacto = await _context.Contactos.FindAsync(new object[] { idUsuario }, cancellationToken);
            if (contacto is null) return false;

            _context.Contactos.Remove(contacto);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<List<Contacto>> ObtenerPaginadosAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Contactos
                .Include(c => c.Usuario)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<Contacto?> ObtenerPorIdAsync(int idUsuario, CancellationToken cancellationToken)
        {
            return await _context.Contactos
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.IdUsuario == idUsuario, cancellationToken);
        }

        public async Task<List<Contacto>> ObtenerTodosAsync(CancellationToken cancellationToken)
        {
            return await _context.Contactos
                .Include(c => c.Usuario)
                .ToListAsync(cancellationToken);
        }
    }
}