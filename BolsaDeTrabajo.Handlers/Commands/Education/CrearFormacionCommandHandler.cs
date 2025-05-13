using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.formacionCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Education
{
    public class CrearFormacionCommandHandler : IRequestHandler<CrearFormacionCommand, bool>
    {
        private readonly IFormacionRepo _repo;

        public CrearFormacionCommandHandler(IFormacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(CrearFormacionCommand request, CancellationToken cancellationToken)
        {
            var formacion = new FormacionAcademica(request.IdAspirante, request.Institucion, request.Titulo, request.FechaInicio, request.TipoFormacion, request.FechaFin);
            formacion.Validate();
            return await _repo.CrearAsync(formacion, cancellationToken);
        }
    }
}
