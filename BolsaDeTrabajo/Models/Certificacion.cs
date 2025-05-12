using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class Certificacion
    {
        public int IdCertificacion { get; set; }
        public int IdAspirante { get; set; }

        public string NombreCertificado { get; set; } = string.Empty;
        public string Institucion { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Resultado { get; set; }
        public string? CodigoCertificado { get; set; }

        // Relación de navegación
        public Aspirante? Aspirante { get; set; }

        public Certificacion(
            int idAspirante,
            string nombreCertificado,
            string institucion,
            DateTime fechaInicio,
            DateTime? fechaFin = null,
            string? resultado = null,
            string? codigoCertificado = null)
        {
            IdAspirante = idAspirante;
            NombreCertificado = nombreCertificado;
            Institucion = institucion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Resultado = resultado;
            CodigoCertificado = codigoCertificado;
        }

        public void Validate()
        {
            if (IdAspirante <= 0)
                throw new ValidationException("El Id del aspirante debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(NombreCertificado))
                throw new ValidationException("El nombre del certificado no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(Institucion))
                throw new ValidationException("La institución no puede estar vacía.");

            if (FechaInicio == default)
                throw new ValidationException("La fecha de inicio no es válida.");

            if (FechaFin.HasValue && FechaFin < FechaInicio)
                throw new ValidationException("La fecha de finalización no puede ser anterior a la de inicio.");
        }
    }
}
