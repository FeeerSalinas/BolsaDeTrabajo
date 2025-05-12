using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class Evento
    {
        public int IdEvento { get; set; }
        public int IdAspirante { get; set; }

        public string NombreEvento { get; set; } = string.Empty;
        public string TipoEvento { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public string Anfitrion { get; set; } = string.Empty;
        public DateTime FechaEvento { get; set; }


        public Aspirante? Aspirante { get; set; }

        public Evento(int idAspirante, string nombreEvento, string tipoEvento, string pais, string anfitrion, DateTime fechaEvento)
        {
            IdAspirante = idAspirante;
            NombreEvento = nombreEvento;
            TipoEvento = tipoEvento;
            Pais = pais;
            Anfitrion = anfitrion;
            FechaEvento = fechaEvento;
        }

        public void Validate()
        {
            if (IdAspirante <= 0)
                throw new ValidationException("El Id del aspirante debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(NombreEvento))
                throw new ValidationException("El nombre del evento no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(TipoEvento))
                throw new ValidationException("El tipo de evento no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(Pais))
                throw new ValidationException("El país no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(Anfitrion))
                throw new ValidationException("El anfitrión no puede estar vacío.");

            if (FechaEvento == default)
                throw new ValidationException("La fecha del evento no es válida.");
        }
    }
}
