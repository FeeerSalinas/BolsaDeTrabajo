using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.aplicacionCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Applications
{
    public class CrearAplicacionCommandHandler : IRequestHandler<CrearAplicacionCommand, bool>
    {
        private readonly IAplicacionOfertaRepo _repo;

        public CrearAplicacionCommandHandler(IAplicacionOfertaRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(CrearAplicacionCommand request, CancellationToken cancellationToken)
        {
            var aplicacion = new AplicacionOferta(request.IdOferta, request.IdAspirante, request.FechaAplicacion, request.Estado);
            aplicacion.Validate();
            return await _repo.CrearAsync(aplicacion, cancellationToken);
        }
    }
}
