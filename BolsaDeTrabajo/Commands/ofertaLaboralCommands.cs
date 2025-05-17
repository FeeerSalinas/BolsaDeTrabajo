using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public class ofertaLaboralCommands
    {
        public record CrearOfertaCommand(
            int IdEmpresa,
            string TituloPuesto,
            string DescripcionPuesto,
            string PerfilAcademico,
            string ExperienciaRequerida,
            decimal SalarioMinimo,
            decimal SalarioMaximo,
            string ModalidadEmpleo,
            string Ubicacion,
            DateTime FechaPublicacion,
            DateTime FechaCierre,
            string EstadoOferta,
            string? ConocimientoNecesarios = null
        ) : IRequest<bool>;

        public record EditarOfertaCommand(
            int IdOferta,
            int IdEmpresa,
            string TituloPuesto,
            string DescripcionPuesto,
            string PerfilAcademico,
            string ExperienciaRequerida,
            decimal SalarioMinimo,
            decimal SalarioMaximo,
            string ModalidadEmpleo,
            string Ubicacion,
            DateTime FechaPublicacion,
            DateTime FechaCierre,
            string EstadoOferta,
            string? ConocimientoNecesarios = null
        ) : IRequest<bool>;

        public record EliminarOfertaCommand(int IdOferta) : IRequest<bool>;
    }
}
