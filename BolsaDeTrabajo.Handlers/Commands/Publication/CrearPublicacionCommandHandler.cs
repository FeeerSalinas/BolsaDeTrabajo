using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.publicacionCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Publication
{
    public class CrearPublicacionCommandHandler : IRequestHandler<CrearPublicacionCommand, bool>
    {
        private readonly IPublicacionRepo _repo;

        public CrearPublicacionCommandHandler(IPublicacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(CrearPublicacionCommand request, CancellationToken cancellationToken)
        {
            var publicacion = new Publicacion(
                request.IdAspirante,
                request.TipoPublicacion,
                request.Titulo,
                request.LugarPublicacion,
                request.FechaPublicacion,
                request.Isbn
            );
            publicacion.Validate();
            return await _repo.CrearAsync(publicacion, cancellationToken);
        }
    }
}
