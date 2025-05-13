using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class formacionQueries
    {
        public record ObtenerFormacionPorIdQuery(int IdFormacion) : IRequest<FormacionAcademica?>;

        public record ObtenerTodasFormacionesQuery : IRequest<List<FormacionAcademica>>;

        public record ObtenerFormacionesPaginadasQuery(int Page, int PageSize) : IRequest<List<FormacionAcademica>>;
    }
}

