using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.examenCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Exam
{
    public class CrearExamenCommandHandler : IRequestHandler<CrearExamenCommand, bool>
    {
        private readonly IExamenRepo _repo;

        public CrearExamenCommandHandler(IExamenRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(CrearExamenCommand request, CancellationToken cancellationToken)
        {
            var examen = new Examen(
                request.IdAspirante,
                request.TipoExamen,
                request.FechaRealizacion,
                request.ResultadoNumerico,
                request.ResultadoCualitativo
            );
            examen.Validate();
            return await _repo.CrearAsync(examen, cancellationToken);
        }
    }
}
