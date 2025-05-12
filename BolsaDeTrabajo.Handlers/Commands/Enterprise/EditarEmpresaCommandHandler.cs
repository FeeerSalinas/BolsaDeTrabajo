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
    public class EditarEmpresaCommandHandler : IRequestHandler<EditarEmpresaCommand, bool>
    {
        private readonly IEmpresaRepo _repo;

        public EditarEmpresaCommandHandler(IEmpresaRepo repo) => _repo = repo;

        public Task<bool> Handle(EditarEmpresaCommand request, CancellationToken cancellationToken)
        {
            var empresa = new Empresa(request.IdUsuario, request.NombreEmpresa, request.NombreRepresentante, request.DescripcionEmpresa)
            {
                IdEmpresa = request.IdEmpresa
            };
            return _repo.EditarAsync(empresa, cancellationToken);
        }
    }
}
