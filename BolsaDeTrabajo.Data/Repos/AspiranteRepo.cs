using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class AspiranteRepo : IAspiranteRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public AspiranteRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<int> CrearAsync(Aspirante aspirante, CancellationToken cancellationToken)
        {
            aspirante.Validate();
            _context.Aspirantes.Add(aspirante);
            await _context.SaveChangesAsync(cancellationToken);
            return aspirante.IdAspirante;
        }

        public async Task<bool> EditarAsync(Aspirante aspirante, CancellationToken cancellationToken)
        {
            var existente = await _context.Aspirantes.FindAsync(new object[] { aspirante.IdAspirante }, cancellationToken);
            if (existente == null) return false;
            existente.PrimerNombre = aspirante.PrimerNombre;
            existente.SegundoNombre = aspirante.SegundoNombre;
            existente.PrimerApellido = aspirante.PrimerApellido;
            existente.SegundoApellido = aspirante.SegundoApellido;
            existente.IdUsuario = aspirante.IdUsuario;
            existente.PuestoBusca = aspirante.PuestoBusca;
            existente.Genero = aspirante.Genero;
            existente.FechaNacimiento = aspirante.FechaNacimiento;
            existente.TipoDocumentoIdentidad = aspirante.TipoDocumentoIdentidad;
            existente.NumeroDocumentoIdentidad = aspirante.NumeroDocumentoIdentidad;
            existente.Nit = aspirante.Nit;
            existente.Nup = aspirante.Nup;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> EliminarAsync(int idAspirante, CancellationToken cancellationToken)
        {
            var existente = await _context.Aspirantes.FindAsync(new object[] { idAspirante }, cancellationToken);
            if (existente == null) return false;

            _context.Aspirantes.Remove(existente);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<Aspirante>> ObtenerAspirantesPorPuesto(string puestoBusca, CancellationToken cancellationToken)
        {
            return await _context.Aspirantes
                 .Include(u => u.Usuario)
                 .Where(a => a.PuestoBusca == puestoBusca)
                 .ToListAsync();
        }

        public async Task<List<Aspirante>> ObtenerPaginadosAsync(int pagina, int tamanoPagina, CancellationToken cancellationToken)
        {
            return await _context.Aspirantes
                .Include(a => a.Usuario)
                .Skip((pagina - 1) * tamanoPagina)
                .Take(tamanoPagina)
                .ToListAsync(cancellationToken);
        }

        public async Task<Aspirante?> ObtenerPorIdAsync(int idAspirante, CancellationToken cancellationToken)
        {
            return await _context.Aspirantes
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(a => a.IdAspirante == idAspirante, cancellationToken);
        }

        public async Task<List<Aspirante>> ObtenerTodosAsync(CancellationToken cancellationToken)
        {
            return await _context.Aspirantes
                .Include(a => a.Usuario)
                .ToListAsync(cancellationToken);
        }
    }
}