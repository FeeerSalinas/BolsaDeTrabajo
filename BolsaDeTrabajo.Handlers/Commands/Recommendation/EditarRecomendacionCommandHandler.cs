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
    public class EditarRecomendacionCommandHandler : IRequestHandler<EditarRecomendacionCommand, bool>
    {
        private readonly IRecomendacionRepo _repo;

        public EditarRecomendacionCommandHandler(IRecomendacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EditarRecomendacionCommand request, CancellationToken cancellationToken)
        {
            var recomendacion = new Recomendacion(request.IdAspirante, request.NombreRecomendador, request.Relacion, request.Telefono)
            {
                IdRecomendacion = request.IdRecomendacion
            };
            recomendacion.Validate();
            return await _repo.EditarAsync(recomendacion, cancellationToken);
        }
    }
}
