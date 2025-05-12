using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Commands
{
    public class experienciaCommands
    {
        public record CrearExperienciaCommand(
            int IdAspirante,
            string PuestoTrabajo,
            string NombreEmpresa,
            DateTime FechaInicio,
            DateTime? FechaFin,
            string Funciones,
            string? TelefonoEmpresa
        ) : IRequest<bool>;

        public record EditarExperienciaCommand(
            int IdExperiencia,
            int IdAspirante,
            string PuestoTrabajo,
            string NombreEmpresa,
            DateTime FechaInicio,
            DateTime? FechaFin,
            string Funciones,
            string? TelefonoEmpresa
        ) : IRequest<bool>;

        public record EliminarExperienciaCommand(int IdExperiencia) : IRequest<bool>;
    }
}
