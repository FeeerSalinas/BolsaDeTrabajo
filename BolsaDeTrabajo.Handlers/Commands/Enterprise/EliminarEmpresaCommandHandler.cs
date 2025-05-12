using BolsaDeTrabajo.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.EmpresaCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Enterprise
{
    public class EliminarEmpresaCommandHandler : IRequestHandler<EliminarEmpresaCommand, bool>
    {
        private readonly IEmpresaRepo _repo;

        public EliminarEmpresaCommandHandler(IEmpresaRepo repo) => _repo = repo;

        public Task<bool> Handle(EliminarEmpresaCommand request, CancellationToken cancellationToken)
        {
            return _repo.EliminarAsync(request.IdEmpresa, cancellationToken);
        }
    }
}
