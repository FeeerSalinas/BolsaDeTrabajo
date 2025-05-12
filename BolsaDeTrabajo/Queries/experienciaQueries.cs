using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Queries
{
    public class experienciaQueries
    {
        public record ObtenerExperienciaPorIdQuery(int IdExperiencia) : IRequest<ExperienciaLaboral?>;

        public record ObtenerTodasExperienciasQuery : IRequest<List<ExperienciaLaboral>>;

        public record ObtenerExperienciasPaginadasQuery(int Page, int PageSize) : IRequest<List<ExperienciaLaboral>>;
    }
}
