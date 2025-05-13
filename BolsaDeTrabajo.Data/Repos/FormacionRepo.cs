using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class FormacionRepo : IFormacionRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public FormacionRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearAsync(FormacionAcademica formacion, CancellationToken cancellationToken)
        {
            _context.FormacionesAcademicas.Add(formacion);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EditarAsync(FormacionAcademica formacion, CancellationToken cancellationToken)
        {
            var existente = await _context.FormacionesAcademicas.FindAsync(new object[] { formacion.IdFormacion }, cancellationToken);
            if (existente is null) return false;

            existente.Institucion = formacion.Institucion;
            existente.Titulo = formacion.Titulo;
            existente.FechaInicio = formacion.FechaInicio;
            existente.FechaFin = formacion.FechaFin;
            existente.TipoFormacion = formacion.TipoFormacion;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EliminarAsync(int idFormacion, CancellationToken cancellationToken)
        {
            var existente = await _context.FormacionesAcademicas.FindAsync(new object[] { idFormacion }, cancellationToken);
            if (existente is null) return false;

            _context.FormacionesAcademicas.Remove(existente);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<FormacionAcademica?> ObtenerPorIdAsync(int idFormacion, CancellationToken cancellationToken)
        {
            return await _context.FormacionesAcademicas
                .Include(f => f.Aspirante)
                .ThenInclude(a => a!.Usuario)
                .FirstOrDefaultAsync(f => f.IdFormacion == idFormacion, cancellationToken);
        }

        public async Task<List<FormacionAcademica>> ObtenerTodasAsync(CancellationToken cancellationToken)
        {
            return await _context.FormacionesAcademicas
                .Include(f => f.Aspirante)
                .ThenInclude(a => a.Usuario)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<FormacionAcademica>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.FormacionesAcademicas
                .Include(f => f.Aspirante)
                .ThenInclude(a => a.Usuario)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
    }
}
