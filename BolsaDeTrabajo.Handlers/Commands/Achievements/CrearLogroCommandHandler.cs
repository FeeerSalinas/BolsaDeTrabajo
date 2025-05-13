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
    public class CrearLogroCommandHandler : IRequestHandler<CrearLogroCommand, bool>
    {
        private readonly ILogroRepo _repo;

        public CrearLogroCommandHandler(ILogroRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(CrearLogroCommand request, CancellationToken cancellationToken)
        {
            var logro = new Logro(request.IdAspirante, request.DescripcionLogro, request.FechaLogro, request.TipoLogro);
            logro.Validate();
            return await _repo.CrearAsync(logro, cancellationToken);
        }
    }
}
