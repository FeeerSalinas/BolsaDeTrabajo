using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.logroCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Achievements
{
    public class EditarLogroCommandHandler : IRequestHandler<EditarLogroCommand, bool>
    {
        private readonly ILogroRepo _repo;

        public EditarLogroCommandHandler(ILogroRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EditarLogroCommand request, CancellationToken cancellationToken)
        {
            var logro = new Logro(request.IdAspirante, request.DescripcionLogro, request.FechaLogro, request.TipoLogro)
            {
                IdLogro = request.IdLogro
            };
            logro.Validate();
            return await _repo.EditarAsync(logro, cancellationToken);
        }
    }
}
