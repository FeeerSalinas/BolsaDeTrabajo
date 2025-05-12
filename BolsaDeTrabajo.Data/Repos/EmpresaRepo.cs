using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Data.Repos
{
    public class EmpresaRepo : IEmpresaRepo
    {
        private readonly BolsaDeTrabajoContext _context;

        public EmpresaRepo(BolsaDeTrabajoContext context)
        {
            _context = context;
        }

        public async Task<int> CrearAsync(Empresa empresa, CancellationToken cancellationToken)
        {
            empresa.Validate();
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync(cancellationToken);
            return empresa.IdEmpresa;
        }

        public async Task<bool> EditarAsync(Empresa empresa, CancellationToken cancellationToken)
        {
            var existente = await _context.Empresas.FindAsync(new object[] { empresa.IdEmpresa }, cancellationToken);
            if (existente is null) return false;

            existente.IdUsuario = empresa.IdUsuario;
            existente.NombreEmpresa = empresa.NombreEmpresa;
            existente.NombreRepresentante = empresa.NombreRepresentante;
            existente.DescripcionEmpresa = empresa.DescripcionEmpresa;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> EliminarAsync(int idEmpresa, CancellationToken cancellationToken)
        {
            var existente = await _context.Empresas.FindAsync(new object[] { idEmpresa }, cancellationToken);
            if (existente is null) return false;

            _context.Empresas.Remove(existente);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<Empresa>> ObtenerPaginadasAsync(int pagina, int tamañoPagina, CancellationToken cancellationToken)
        {
            return await _context.Empresas
                .Include(e => e.Usuario)
                .Skip((pagina - 1) * tamañoPagina)
                .Take(tamañoPagina)
                .ToListAsync(cancellationToken);
        }

        public async Task<Empresa?> ObtenerPorIdAsync(int idEmpresa, CancellationToken cancellationToken)
        {
            return await _context.Empresas
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(e => e.IdEmpresa == idEmpresa, cancellationToken);
        }

        public async Task<List<Empresa>> ObtenerTodasAsync(CancellationToken cancellationToken)
        {
            return await _context.Empresas
                .Include(e => e.Usuario)
                .ToListAsync(cancellationToken);
        }
    }
}
