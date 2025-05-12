using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class Logro
    {
        public int IdLogro { get; set; }
        public int IdAspirante { get; set; }

        public string DescripcionLogro { get; set; } = string.Empty;
        public DateTime FechaLogro { get; set; }
        public string? TipoLogro { get; set; }

        public Aspirante? Aspirante { get; set; }

        public Logro(int idAspirante, string descripcionLogro, DateTime fechaLogro, string? tipoLogro = null)
        {
            IdAspirante = idAspirante;
            DescripcionLogro = descripcionLogro;
            FechaLogro = fechaLogro;
            TipoLogro = tipoLogro;
        }

        public void Validate()
        {
            if (IdAspirante <= 0)
                throw new ValidationException("El Id del aspirante debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(DescripcionLogro))
                throw new ValidationException("La descripción del logro no puede estar vacía.");

            if (FechaLogro == default)
                throw new ValidationException("La fecha del logro no es válida.");
        }
    }
}
