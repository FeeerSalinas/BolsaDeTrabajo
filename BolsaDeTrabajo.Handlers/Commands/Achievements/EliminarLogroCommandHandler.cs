using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.logroCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Achievements
{
    public class EliminarLogroCommandHandler : IRequestHandler<EliminarLogroCommand, bool>
    {
        private readonly ILogroRepo _repo;

        public EliminarLogroCommandHandler(ILogroRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EliminarLogroCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdLogro, cancellationToken);
        }
    }
}
