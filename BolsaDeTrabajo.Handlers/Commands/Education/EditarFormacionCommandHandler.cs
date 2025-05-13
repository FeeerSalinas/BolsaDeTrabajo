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
    public class EditarFormacionCommandHandler : IRequestHandler<EditarFormacionCommand, bool>
    {
        private readonly IFormacionRepo _repo;

        public EditarFormacionCommandHandler(IFormacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EditarFormacionCommand request, CancellationToken cancellationToken)
        {
            var formacion = new FormacionAcademica(request.IdAspirante, request.Institucion, request.Titulo, request.FechaInicio, request.TipoFormacion, request.FechaFin)
            {
                IdFormacion = request.IdFormacion
            };
            formacion.Validate();
            return await _repo.EditarAsync(formacion, cancellationToken);
        }
    }

}
