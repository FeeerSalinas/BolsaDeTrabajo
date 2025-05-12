using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class Aspirante
    {
        public int IdAspirante { get; set; }
        public int IdUsuario { get; set; }

        public string PrimerNombre { get; set; } = string.Empty;
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = string.Empty;
        public string? SegundoApellido { get; set; }

        public Usuario? Usuario { get; set; }

        public Aspirante(int idUsuario, string primerNombre, string primerApellido, string? segundoNombre = null, string? segundoApellido = null)
        {
            IdUsuario = idUsuario;
            PrimerNombre = primerNombre;
            PrimerApellido = primerApellido;
            SegundoNombre = segundoNombre;
            SegundoApellido = segundoApellido;
        }
        public void Validate()
        {
            if (IdUsuario <= 0)
                throw new ValidationException("El Id del usuario debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(PrimerNombre))
                throw new ValidationException("El primer nombre no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(PrimerApellido))
                throw new ValidationException("El primer apellido no puede estar vacío.");
        }
    }
}
