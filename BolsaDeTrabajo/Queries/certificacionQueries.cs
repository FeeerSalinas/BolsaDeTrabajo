using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class certificacionQueries
    {
        public record ObtenerCertificacionPorIdQuery(int IdCertificacion) : IRequest<Certificacion?>;

        public record ObtenerTodasCertificacionesQuery : IRequest<List<Certificacion>>;

        public record ObtenerCertificacionesPaginadasQuery(int Page, int PageSize) : IRequest<List<Certificacion>>;
    }
}
