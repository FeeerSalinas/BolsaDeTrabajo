using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class documentsQueries
    {
        public record ObtenerDocumentoPorIdQuery(int IdAspirante) : IRequest<DocumentosAspirante?>;

        public record ObtenerTodosDocumentosQuery() : IRequest<List<DocumentosAspirante>>;

        public record ObtenerDocumentosPaginadosQuery(int Page, int PageSize) : IRequest<List<DocumentosAspirante>>;
    }
}
