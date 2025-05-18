using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class OfertaRepo : IOfertaRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public OfertaRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearAsync(OfertaLaboral oferta, CancellationToken cancellationToken)
        {
            _context.OfertasLaborales.Add(oferta);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EditarAsync(OfertaLaboral oferta, CancellationToken cancellationToken)
        {
            var existente = await _context.OfertasLaborales.FindAsync(new object[] { oferta.IdOferta }, cancellationToken);
            if (existente is null) return false;

            existente.IdEmpresa = oferta.IdEmpresa;
            existente.TituloPuesto = oferta.TituloPuesto;
            existente.DescripcionPuesto = oferta.DescripcionPuesto;
            existente.ConocimientoNecesarios = oferta.ConocimientoNecesarios;
            existente.PerfilAcademico = oferta.PerfilAcademico;
            existente.ExperienciaRequerida = oferta.ExperienciaRequerida;
            existente.SalarioMinimo = oferta.SalarioMinimo;
            existente.SalarioMaximo = oferta.SalarioMaximo;
            existente.ModalidadEmpleo = oferta.ModalidadEmpleo;
            existente.Ubicacion = oferta.Ubicacion;
            existente.FechaPublicacion = oferta.FechaPublicacion;
            existente.FechaCierre = oferta.FechaCierre;
            existente.EstadoOferta = oferta.EstadoOferta;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> EliminarAsync(int idOferta, CancellationToken cancellationToken)
        {
            var existente = await _context.OfertasLaborales.FindAsync(new object[] { idOferta }, cancellationToken);
            if (existente is null) return false;

            _context.OfertasLaborales.Remove(existente);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<OfertaLaboral?> ObtenerPorIdAsync(int idOferta, CancellationToken cancellationToken)
        {
            return await _context.OfertasLaborales
                .Include(o => o.Empresa)
                    .ThenInclude(e => e.Usuario)
                .FirstOrDefaultAsync(o => o.IdOferta == idOferta, cancellationToken);
        }

        public async Task<List<OfertaLaboral>> ObtenerTodasAsync(CancellationToken cancellationToken)
        {
            return await _context.OfertasLaborales
                .Include(o => o.Empresa)
                    .ThenInclude(e => e.Usuario)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<OfertaLaboral>> ObtenerPaginadoAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.OfertasLaborales
                .Include(o => o.Empresa)
                    .ThenInclude(e => e.Usuario)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<OfertaLaboral>> ObtenerOfertaPorPerfil(string perfilAcademico, CancellationToken cancellationToken)
        {
            return await _context.OfertasLaborales
                .Include(o => o.Empresa)
                    .ThenInclude(e => e.Usuario)
                .Where(o => o.PerfilAcademico == perfilAcademico)
                .ToListAsync();
        }
    }
}
