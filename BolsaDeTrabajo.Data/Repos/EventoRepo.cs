using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class EventoRepo : IEventoRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public EventoRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearAsync(Evento evento, CancellationToken cancellationToken)
        {
            _context.Eventos.Add(evento);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EditarAsync(Evento evento, CancellationToken cancellationToken)
        {
            var existente = await _context.Eventos.FindAsync(new object[] { evento.IdEvento }, cancellationToken);
            if (existente is null) return false;

            existente.NombreEvento = evento.NombreEvento;
            existente.TipoEvento = evento.TipoEvento;
            existente.Pais = evento.Pais;
            existente.Anfitrion = evento.Anfitrion;
            existente.FechaEvento = evento.FechaEvento;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EliminarAsync(int idEvento, CancellationToken cancellationToken)
        {
            var existente = await _context.Eventos.FindAsync(new object[] { idEvento }, cancellationToken);
            if (existente is null) return false;

            _context.Eventos.Remove(existente);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<Evento?> ObtenerPorIdAsync(int idEvento, CancellationToken cancellationToken)
        {
            return await _context.Eventos
                .Include(e => e.Aspirante)
                .ThenInclude(a => a.Usuario)
                .FirstOrDefaultAsync(e => e.IdEvento == idEvento, cancellationToken);
        }

        public async Task<List<Evento>> ObtenerTodosAsync(CancellationToken cancellationToken)
        {
            return await _context.Eventos
                .Include(e => e.Aspirante)
                .ThenInclude(a => a.Usuario)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Evento>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Eventos
                .Include(e => e.Aspirante)
                .ThenInclude(a => a.Usuario)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
    }
}
