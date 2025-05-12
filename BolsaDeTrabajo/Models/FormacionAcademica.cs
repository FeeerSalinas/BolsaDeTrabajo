using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class FormacionAcademica
    {
        public int IdFormacion { get; set; }
        public int IdAspirante { get; set; }

        public string Institucion { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string TipoFormacion { get; set; } = string.Empty;

        public Aspirante? Aspirante { get; set; }

        public FormacionAcademica(
            int idAspirante,
            string institucion,
            string titulo,
            DateTime fechaInicio,
            string tipoFormacion,
            DateTime? fechaFin = null)
        {
            IdAspirante = idAspirante;
            Institucion = institucion;
            Titulo = titulo;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            TipoFormacion = tipoFormacion;
        }

        public void Validate()
        {
            if (IdAspirante <= 0)
                throw new ValidationException("El Id del aspirante debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(Institucion))
                throw new ValidationException("La institución no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(Titulo))
                throw new ValidationException("El título no puede estar vacío.");

            if (FechaInicio == default)
                throw new ValidationException("La fecha de inicio no es válida.");

            if (FechaFin.HasValue && FechaFin < FechaInicio)
                throw new ValidationException("La fecha de fin no puede ser anterior a la fecha de inicio.");

            if (string.IsNullOrWhiteSpace(TipoFormacion))
                throw new ValidationException("El tipo de formación no puede estar vacío.");
        }
    }
}
