﻿using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BolsaDeTrabajo.Queries.formacionQueries;

namespace BolsaDeTrabajo.Handlers.Queries.Education
{
    public class ObtenerFormacionPorIdHandler : IRequestHandler<ObtenerFormacionPorIdQuery, FormacionAcademica?>
    {
        private readonly IFormacionRepo _repo;

        public ObtenerFormacionPorIdHandler(IFormacionRepo repo)
        {
            _repo = repo;
        }

        public async Task<FormacionAcademica?> Handle(ObtenerFormacionPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObtenerPorIdAsync(request.IdFormacion, cancellationToken);
        }
    }
}
