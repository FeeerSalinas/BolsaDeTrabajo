using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class ExperienciaLaboral
    {
        public int IdExperiencia { get; set; }
        public int IdAspirante { get; set; }

        public string PuestoTrabajo { get; set; } = string.Empty;
        public string NombreEmpresa { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Funciones { get; set; } = string.Empty;
        public string? TelefonoEmpresa { get; set; }

        public Aspirante? Aspirante { get; set; }

        public ExperienciaLaboral(
            int idAspirante,
            string puestoTrabajo,
            string nombreEmpresa,
            DateTime fechaInicio,
            string funciones,
            DateTime? fechaFin = null,
            string? telefonoEmpresa = null)
        {
            IdAspirante = idAspirante;
            PuestoTrabajo = puestoTrabajo;
            NombreEmpresa = nombreEmpresa;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Funciones = funciones;
            TelefonoEmpresa = telefonoEmpresa;
        }

        public void Validate()
        {
            if (IdAspirante <= 0)
                throw new ValidationException("El Id del aspirante debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(PuestoTrabajo))
                throw new ValidationException("El puesto de trabajo no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(NombreEmpresa))
                throw new ValidationException("El nombre de la empresa no puede estar vacío.");

            if (FechaInicio == default)
                throw new ValidationException("La fecha de inicio no es válida.");

            if (FechaFin.HasValue && FechaFin < FechaInicio)
                throw new ValidationException("La fecha de fin no puede ser anterior a la fecha de inicio.");

            if (string.IsNullOrWhiteSpace(Funciones))
                throw new ValidationException("Las funciones no pueden estar vacías.");
        }
    }
}
