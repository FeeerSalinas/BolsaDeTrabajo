using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.habilidadCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Skills
{
    public class CrearHabilidadCommandHandler : IRequestHandler<CrearHabilidadCommand, bool>
    {
        private readonly IHabilidadRepo _repo;

        public CrearHabilidadCommandHandler(IHabilidadRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(CrearHabilidadCommand request, CancellationToken cancellationToken)
        {
            var habilidad = new Habilidad(request.IdAspirante, request.NombreHabilidad, request.NivelDominio, request.Comentario);
            habilidad.Validate();
            return await _repo.CrearAsync(habilidad, cancellationToken);
        }
    }
}
