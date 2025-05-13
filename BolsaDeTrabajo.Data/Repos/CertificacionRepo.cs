using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class CertificacionRepo : ICertificacionRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public CertificacionRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearAsync(Certificacion certificacion, CancellationToken cancellationToken)
        {
            _context.Certificaciones.Add(certificacion);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EditarAsync(Certificacion certificacion, CancellationToken cancellationToken)
        {
            var existente = await _context.Certificaciones.FindAsync(new object[] { certificacion.IdCertificacion }, cancellationToken);
            if (existente is null) return false;

            existente.NombreCertificado = certificacion.NombreCertificado;
            existente.Institucion = certificacion.Institucion;
            existente.FechaInicio = certificacion.FechaInicio;
            existente.FechaFin = certificacion.FechaFin;
            existente.Resultado = certificacion.Resultado;
            existente.CodigoCertificado = certificacion.CodigoCertificado;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EliminarAsync(int idCertificacion, CancellationToken cancellationToken)
        {
            var existente = await _context.Certificaciones.FindAsync(new object[] { idCertificacion }, cancellationToken);
            if (existente is null) return false;

            _context.Certificaciones.Remove(existente);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<Certificacion?> ObtenerPorIdAsync(int idCertificacion, CancellationToken cancellationToken)
        {
            return await _context.Certificaciones
                .Include(c => c.Aspirante)
                .ThenInclude(a => a!.Usuario)
                .FirstOrDefaultAsync(c => c.IdCertificacion == idCertificacion, cancellationToken);
        }

        public async Task<List<Certificacion>> ObtenerTodasAsync(CancellationToken cancellationToken)
        {
            return await _context.Certificaciones
                .Include(c => c.Aspirante)
                .ThenInclude(a => a.Usuario)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Certificacion>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Certificaciones
                .Include(c => c.Aspirante)
                .ThenInclude(a => a.Usuario)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
    }
}

