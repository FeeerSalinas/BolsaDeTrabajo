using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class aspiranteQueries
    {
        // ✅ QUERIES EXISTENTES (sin modificar)
        public record ObtenerAspirantePorIdQuery(int IdAspirante) : IRequest<Aspirante?>;
        public record ObtenerAspirantesQuery : IRequest<List<Aspirante>>;
        public record ObtenerAspirantesPaginadosQuery(int Pagina, int TamanoPagina) : IRequest<List<Aspirante>>;
        public record ObtenersAspirantesPorPuesto(string puestoBusca) : IRequest<List<Aspirante>>;

        // 🆕 NUEVAS QUERIES AGREGADAS
        public record ObtenerTodosAspirantesQuery() : IRequest<List<Aspirante>>;
        public record ObtenerAspirantePorUsuarioQuery(int IdUsuario) : IRequest<Aspirante?>;
        public record ObtenerAspirantePorDocumentoQuery(string NumeroDocumento) : IRequest<Aspirante?>;
        public record ObtenerAspirantePorNitQuery(string Nit) : IRequest<Aspirante?>;
        public record ObtenerAspirantePorNupQuery(string Nup) : IRequest<Aspirante?>;
        public record ObtenerAspirantesPorRangoEdadQuery(int EdadMinima, int EdadMaxima) : IRequest<List<Aspirante>>;
    }
}
