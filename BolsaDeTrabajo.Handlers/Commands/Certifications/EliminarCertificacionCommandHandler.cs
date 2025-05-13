using BolsaDeTrabajo.Commands;
using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Handlers.Commands.Certifications
{
    public class EliminarCertificacionCommandHandler : IRequestHandler<certificacionCommands.EliminarCertificacionCommand, bool>
    {
        private readonly ICertificacionRepo _repo;

        public EliminarCertificacionCommandHandler(ICertificacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(certificacionCommands.EliminarCertificacionCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdCertificacion, cancellationToken);
        }
    }
}
