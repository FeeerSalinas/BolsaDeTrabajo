using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class EmpresaQueries
    {
        public record ObtenerEmpresaPorIdQuery(int IdEmpresa) : IRequest<Empresa?>;
        public record ObtenerTodasEmpresasQuery() : IRequest<List<Empresa>>;
        public record ObtenerEmpresasPaginadasQuery(int Pagina, int TamañoPagina) : IRequest<List<Empresa>>;
    }
}
