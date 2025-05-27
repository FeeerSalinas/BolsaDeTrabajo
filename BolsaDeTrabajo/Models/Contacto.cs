using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class Contacto
    {
        public int IdUsuario { get; set; }
        public string TelefonoPersonal { get; set; } = string.Empty;
        public string TelefonoFijo { get; set; } = string.Empty;

        public string? RedesSociales { get; set; }

        public Usuario? Usuario { get; set; }


        public Contacto(
            int idUsuario,
            string telefonoPersonal,
            string telefonoFijo,
            string? redesSociales = null)
        {
            IdUsuario = idUsuario;
            TelefonoPersonal = telefonoPersonal;
            TelefonoFijo = telefonoFijo;
            RedesSociales = redesSociales;
        }

        public void Validate()
        {
            if (IdUsuario <= 0)
                throw new ValidationException("El Id del usuario debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(TelefonoPersonal))
                throw new ValidationException("El teléfono personal no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(TelefonoFijo))
                throw new ValidationException("El teléfono fijo no puede estar vacío.");

            if (!string.IsNullOrEmpty(RedesSociales) && RedesSociales.Length > 1000)
                throw new ValidationException("Las redes sociales no pueden exceder 1000 caracteres.");
        }
    }
}