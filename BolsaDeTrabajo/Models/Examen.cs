using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class Examen
    {
        public int IdExamen { get; set; }
        public int IdAspirante { get; set; }

        public string TipoExamen { get; set; } = string.Empty;
        public decimal? ResultadoNumerico { get; set; }
        public DateTime FechaRealizacion { get; set; }
        public string? ResultadoCualitativo { get; set; }

        // Relación de navegación
        public Aspirante? Aspirante { get; set; }

        public Examen(
            int idAspirante,
            string tipoExamen,
            DateTime fechaRealizacion,
            decimal? resultadoNumerico = null,
            string? resultadoCualitativo = null)
        {
            IdAspirante = idAspirante;
            TipoExamen = tipoExamen;
            FechaRealizacion = fechaRealizacion;
            ResultadoNumerico = resultadoNumerico;
            ResultadoCualitativo = resultadoCualitativo;
        }

        public void Validate()
        {
            if (IdAspirante <= 0)
                throw new ValidationException("El Id del aspirante debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(TipoExamen))
                throw new ValidationException("El tipo de examen no puede estar vacío.");

            if (FechaRealizacion == default)
                throw new ValidationException("La fecha de realización no es válida.");
        }
    }
}
