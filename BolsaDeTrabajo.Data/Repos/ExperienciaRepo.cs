using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class ExperienciaRepo : IExperienciaRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public ExperienciaRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearAsync(ExperienciaLaboral experiencia, CancellationToken cancellationToken)
        {
            _context.ExperienciasLaborales.Add(experiencia);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EditarAsync(ExperienciaLaboral experiencia, CancellationToken cancellationToken)
        {
            var existente = await _context.ExperienciasLaborales.FindAsync(new object[] { experiencia.IdExperiencia }, cancellationToken);
            if (existente is null) return false;

            existente.PuestoTrabajo = experiencia.PuestoTrabajo;
            existente.NombreEmpresa = experiencia.NombreEmpresa;
            existente.FechaInicio = experiencia.FechaInicio;
            existente.FechaFin = experiencia.FechaFin;
            existente.Funciones = experiencia.Funciones;
            existente.TelefonoEmpresa = experiencia.TelefonoEmpresa;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EliminarAsync(int idExperiencia, CancellationToken cancellationToken)
        {
            var existente = await _context.ExperienciasLaborales.FindAsync(new object[] { idExperiencia }, cancellationToken);
            if (existente is null) return false;

            _context.ExperienciasLaborales.Remove(existente);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<ExperienciaLaboral?> ObtenerPorIdAsync(int idExperiencia, CancellationToken cancellationToken)
        {
            return await _context.ExperienciasLaborales
                .Include(e => e.Aspirante)
                    .ThenInclude(a => a!.Usuario)
                .FirstOrDefaultAsync(e => e.IdExperiencia == idExperiencia, cancellationToken);
        }

        public async Task<List<ExperienciaLaboral>> ObtenerTodasAsync(CancellationToken cancellationToken)
        {
            return await _context.ExperienciasLaborales
                .Include(e => e.Aspirante)
                    .ThenInclude(a => a!.Usuario)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<ExperienciaLaboral>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.ExperienciasLaborales
                .Include(e => e.Aspirante)
                    .ThenInclude(a => a!.Usuario)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
    }
}
