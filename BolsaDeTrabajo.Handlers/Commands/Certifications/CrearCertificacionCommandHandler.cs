using BolsaDeTrabajo.Commands;
using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Handlers.Commands.Certifications
{
    public class CrearCertificacionCommandHandler : IRequestHandler<certificacionCommands.CrearCertificacionCommand, bool>
    {
        private readonly ICertificacionRepo _repo;

        public CrearCertificacionCommandHandler(ICertificacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(certificacionCommands.CrearCertificacionCommand request, CancellationToken cancellationToken)
        {
            var cert = new Certificacion(
                request.IdAspirante,
                request.NombreCertificado,
                request.Institucion,
                request.FechaInicio,
                request.FechaFin,
                request.Resultado,
                request.CodigoCertificado
            );
            cert.Validate();
            return await _repo.CrearAsync(cert, cancellationToken);
        }
    }
}
