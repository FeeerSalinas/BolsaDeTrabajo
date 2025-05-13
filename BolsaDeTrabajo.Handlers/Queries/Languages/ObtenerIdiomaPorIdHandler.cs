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
    public class ObtenerIdiomaPorIdHandler : IRequestHandler<ObtenerIdiomaPorIdQuery, Idioma?>
    {
        private readonly IIdiomaRepo _repo;

        public ObtenerIdiomaPorIdHandler(IIdiomaRepo repo)
        {
            _repo = repo;
        }

        public async Task<Idioma?> Handle(ObtenerIdiomaPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdIdioma, cancellationToken);
        }
    }
}
