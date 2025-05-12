using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string Correo { get; set; } = string.Empty;

        public string Clave { get; set; } = string.Empty;

        public string Rol { get; set; } = string.Empty;

        public DateTimeOffset FechaRegistro { get; set; }

        public Usuario(string correo, string clave, string rol)
        {
            Correo = correo;
            Clave = clave;
            Rol = rol;
            FechaRegistro = DateTimeOffset.Now;
        }
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Correo))
                throw new ValidationException("El correo no puede estar vacío.");

            if (!Correo.Contains("@") || !Correo.Contains("."))
                throw new ValidationException("El formato del correo no es válido.");

            if (string.IsNullOrWhiteSpace(Clave))
                throw new ValidationException("La clave no puede estar vacía.");

            if (Clave.Length < 6)
                throw new ValidationException("La clave debe tener al menos 6 caracteres.");

            if (string.IsNullOrWhiteSpace(Rol))
                throw new ValidationException("El rol no puede estar vacío.");
        }
    }
}
