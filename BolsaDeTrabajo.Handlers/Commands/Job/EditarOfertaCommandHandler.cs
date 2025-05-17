using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.ofertaLaboralCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Job
{
    public class EditarOfertaCommandHandler : IRequestHandler<EditarOfertaCommand, bool>
    {
        private readonly IOfertaRepo _repo;

        public EditarOfertaCommandHandler(IOfertaRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EditarOfertaCommand request, CancellationToken cancellationToken)
        {
            var oferta = new OfertaLaboral(
                request.IdEmpresa,
                request.TituloPuesto,
                request.DescripcionPuesto,
                request.PerfilAcademico,
                request.ExperienciaRequerida,
                request.SalarioMinimo,
                request.SalarioMaximo,
                request.ModalidadEmpleo,
                request.Ubicacion,
                request.FechaPublicacion,
                request.FechaCierre,
                request.EstadoOferta,
                request.ConocimientoNecesarios
            )
            {
                IdOferta = request.IdOferta
            };

            oferta.Validate();
            return await _repo.EditarAsync(oferta, cancellationToken);
        }
    }
}
