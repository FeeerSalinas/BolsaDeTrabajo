using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class AplicacionOferta
    {
        public int IdAplicacion { get; set; }
        public int IdOferta { get; set; }
        public int IdAspirante { get; set; }

        public DateTime FechaAplicacion { get; set; }
        public string Estado { get; set; } = string.Empty;

        public Aspirante? Aspirante { get; set; }
        public OfertaLaboral? Oferta { get; set; }

        public AplicacionOferta(int idOferta, int idAspirante, DateTime fechaAplicacion, string estado)
        {
            IdOferta = idOferta;
            IdAspirante = idAspirante;
            FechaAplicacion = fechaAplicacion;
            Estado = estado;
        }
        public void Validate()
        {
            if (IdOferta <= 0)
                throw new ValidationException("El Id de la oferta debe ser mayor que 0.");

            if (IdAspirante <= 0)
                throw new ValidationException("El Id del aspirante debe ser mayor que 0.");

            if (FechaAplicacion == default)
                throw new ValidationException("La fecha de aplicación no es válida.");

            if (string.IsNullOrWhiteSpace(Estado))
                throw new ValidationException("El estado no puede estar vacío.");
        }
    }
}
