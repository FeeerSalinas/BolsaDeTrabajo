using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.habilidadCommands;
using static BolsaDeTrabajo.Commands.recomendacionCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Recommendation
{
    public class CrearRecomendacionCommandHandler : IRequestHandler<CrearRecomendacionCommand, bool>
    {
        private readonly IRecomendacionRepo _repo;

        public CrearRecomendacionCommandHandler(IRecomendacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(CrearRecomendacionCommand request, CancellationToken cancellationToken)
        {
            var recomendacion = new Recomendacion(request.IdAspirante, request.NombreRecomendador, request.Relacion, request.Telefono);
            recomendacion.Validate();
            return await _repo.CrearAsync(recomendacion, cancellationToken);
        }
    }

}
