using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class Recomendacion
    {
        public int IdRecomendacion { get; set; }
        public int IdAspirante { get; set; }

        public string NombreRecomendador { get; set; } = string.Empty;
        public string Relacion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

        public Aspirante? Aspirante { get; set; }

        public Recomendacion(int idAspirante, string nombreRecomendador, string relacion, string telefono)
        {
            IdAspirante = idAspirante;
            NombreRecomendador = nombreRecomendador;
            Relacion = relacion;
            Telefono = telefono;
        }

        public void Validate()
        {
            if (IdAspirante <= 0)
                throw new ValidationException("El Id del aspirante debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(NombreRecomendador))
                throw new ValidationException("El nombre del recomendador no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(Relacion))
                throw new ValidationException("La relación no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(Telefono))
                throw new ValidationException("El teléfono no puede estar vacío.");
        }
    }
}
