using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class Habilidad
    {
        public int IdHabilidad { get; set; }
        public int IdAspirante { get; set; }

        public string NombreHabilidad { get; set; } = string.Empty;
        public string NivelDominio { get; set; } = string.Empty;
        public string? Comentario { get; set; }

        public Aspirante? Aspirante { get; set; }

        public Habilidad(int idAspirante, string nombreHabilidad, string nivelDominio, string? comentario = null)
        {
            IdAspirante = idAspirante;
            NombreHabilidad = nombreHabilidad;
            NivelDominio = nivelDominio;
            Comentario = comentario;
        }

        public void Validate()
        {
            if (IdAspirante <= 0)
                throw new ValidationException("El Id del aspirante debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(NombreHabilidad))
                throw new ValidationException("El nombre de la habilidad no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(NivelDominio))
                throw new ValidationException("El nivel de dominio no puede estar vacío.");
        }
    }
}
