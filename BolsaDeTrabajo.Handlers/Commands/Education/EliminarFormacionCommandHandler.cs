using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.formacionCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Education
{
    public class EliminarFormacionCommandHandler : IRequestHandler<EliminarFormacionCommand, bool>
    {
        private readonly IFormacionRepo _repo;

        public EliminarFormacionCommandHandler(IFormacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EliminarFormacionCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdFormacion, cancellationToken);
        }
    }
}
