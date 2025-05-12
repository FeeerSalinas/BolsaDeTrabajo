using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class Idioma
    {
        public int IdIdioma { get; set; }
        public int IdAspirante { get; set; }

        public string NombreIdioma { get; set; } = string.Empty;
        public string NivelLectura { get; set; } = string.Empty;
        public string NivelEscritura { get; set; } = string.Empty;
        public string NivelConversacion { get; set; } = string.Empty;
        public string NivelEscucha { get; set; } = string.Empty;

        public Aspirante? Aspirante { get; set; }

        public Idioma(
            int idAspirante,
            string nombreIdioma,
            string nivelLectura,
            string nivelEscritura,
            string nivelConversacion,
            string nivelEscucha)
        {
            IdAspirante = idAspirante;
            NombreIdioma = nombreIdioma;
            NivelLectura = nivelLectura;
            NivelEscritura = nivelEscritura;
            NivelConversacion = nivelConversacion;
            NivelEscucha = nivelEscucha;
        }

        public void Validate()
        {
            if (IdAspirante <= 0)
                throw new ValidationException("El Id del aspirante debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(NombreIdioma))
                throw new ValidationException("El nombre del idioma no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(NivelLectura))
                throw new ValidationException("El nivel de lectura no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(NivelEscritura))
                throw new ValidationException("El nivel de escritura no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(NivelConversacion))
                throw new ValidationException("El nivel de conversación no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(NivelEscucha))
                throw new ValidationException("El nivel de escucha no puede estar vacío.");
        }
    }
}
