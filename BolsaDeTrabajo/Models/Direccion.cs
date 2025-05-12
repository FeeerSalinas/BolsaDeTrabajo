using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class Direccion
    {
        public int IdUsuario { get; set; }
        public string Departamento { get; set; } = string.Empty;
        public string Municipio { get; set; } = string.Empty;
        public string DetalleDireccion { get; set; } = string.Empty;

        public Usuario? Usuario { get; set; }

        public Direccion(int idUsuario, string departamento, string municipio, string detalleDireccion)
        {
            IdUsuario = idUsuario;
            Departamento = departamento;
            Municipio = municipio;
            DetalleDireccion = detalleDireccion;
        }

        public void Validate()
        {
            if (IdUsuario <= 0)
                throw new ValidationException("El Id del usuario debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(Departamento))
                throw new ValidationException("El departamento no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(Municipio))
                throw new ValidationException("El municipio no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(DetalleDireccion))
                throw new ValidationException("La dirección detallada no puede estar vacía.");
        }
    }
}
