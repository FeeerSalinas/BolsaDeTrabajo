using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Commands.EmpresaCommands;

namespace BolsaDeTrabajo.Handlers.Commands.Enterprise
{
    public class CrearEmpresaCommandHandler : IRequestHandler<CrearEmpresaCommand, int>
    {
        private readonly IEmpresaRepo _repo;

        public CrearEmpresaCommandHandler(IEmpresaRepo repo) => _repo = repo;

        public Task<int> Handle(CrearEmpresaCommand request, CancellationToken cancellationToken)
        {
            var empresa = new Empresa(request.IdUsuario, request.NombreEmpresa, request.NombreRepresentante, request.DescripcionEmpresa);
            return _repo.CrearAsync(empresa, cancellationToken);
        }
    }
}
