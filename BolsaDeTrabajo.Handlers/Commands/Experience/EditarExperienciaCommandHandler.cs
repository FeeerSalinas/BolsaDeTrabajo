using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.experienciaCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Experience
{
    public class EditarExperienciaCommandHandler : IRequestHandler<EditarExperienciaCommand, bool>
    {
        private readonly IExperienciaRepo _repo;

        public EditarExperienciaCommandHandler(IExperienciaRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EditarExperienciaCommand request, CancellationToken cancellationToken)
        {
            var experiencia = new ExperienciaLaboral(
                request.IdAspirante,
                request.PuestoTrabajo,
                request.NombreEmpresa,
                request.FechaInicio,
                request.Funciones,
                request.FechaFin,
                request.TelefonoEmpresa
            )
            {
                IdExperiencia = request.IdExperiencia
            };

            experiencia.Validate();
            return await _repo.EditarAsync(experiencia, cancellationToken);
        }
    }
}
