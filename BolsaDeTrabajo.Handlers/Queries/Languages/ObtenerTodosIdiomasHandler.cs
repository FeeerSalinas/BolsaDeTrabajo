using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.idiomaQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Languages
{
    public class ObtenerTodosIdiomasHandler : IRequestHandler<ObtenerTodosIdiomasQuery, List<Idioma>>
    {
        private readonly IIdiomaRepo _repo;

        public ObtenerTodosIdiomasHandler(IIdiomaRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Idioma>> Handle(ObtenerTodosIdiomasQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerTodosAsync(cancellationToken);
        }
    }
}
