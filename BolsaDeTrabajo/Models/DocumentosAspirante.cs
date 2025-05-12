using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class DocumentosAspirante
    {
        public int IdAspirante { get; set; }
        public string TipoDocumento { get; set; } = string.Empty;
        public string NumeroDocumento { get; set; } = string.Empty;

        public Aspirante? Aspirante { get; set; }

        public DocumentosAspirante(int idAspirante, string tipoDocumento, string numeroDocumento)
        {
            IdAspirante = idAspirante;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
        }

        public void Validate()
        {
            if (IdAspirante <= 0)
                throw new ValidationException("El Id del aspirante debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(TipoDocumento))
                throw new ValidationException("El tipo de documento no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(NumeroDocumento))
                throw new ValidationException("El número de documento no puede estar vacío.");
        }
    }
}
