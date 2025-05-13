using BolsaDeTrabajo.Commands;
using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Handlers.Commands.Languages
{
    public class EliminarIdiomaCommandHandler : IRequestHandler<EliminarIdiomaCommand, bool>
    {
        private readonly IIdiomaRepo _repo;

        public EliminarIdiomaCommandHandler(IIdiomaRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(EliminarIdiomaCommand request, CancellationToken cancellationToken)
        {
            return await _repo.EliminarAsync(request.IdIdioma, cancellationToken);
        }
    }
}
