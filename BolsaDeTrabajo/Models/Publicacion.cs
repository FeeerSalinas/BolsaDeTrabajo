using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class Publicacion
    {
        public int IdPublicacion { get; set; }
        public int IdAspirante { get; set; }

        public string TipoPublicacion { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string LugarPublicacion { get; set; } = string.Empty;
        public DateTime FechaPublicacion { get; set; }
        public string? Isbn { get; set; }

        public Aspirante? Aspirante { get; set; }

        public Publicacion(int idAspirante, string tipoPublicacion, string titulo, string lugarPublicacion, DateTime fechaPublicacion, string? isbn = null)
        {
            IdAspirante = idAspirante;
            TipoPublicacion = tipoPublicacion;
            Titulo = titulo;
            LugarPublicacion = lugarPublicacion;
            FechaPublicacion = fechaPublicacion;
            Isbn = isbn;
        }

        public void Validate()
        {
            if (IdAspirante <= 0)
                throw new ValidationException("El Id del aspirante debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(TipoPublicacion))
                throw new ValidationException("El tipo de publicación no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(Titulo))
                throw new ValidationException("El título no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(LugarPublicacion))
                throw new ValidationException("El lugar de publicación no puede estar vacío.");

            if (FechaPublicacion == default)
                throw new ValidationException("La fecha de publicación debe ser válida.");
        }
    }
}
