using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class Empresa
    {
        public int IdEmpresa { get; set; }
        public int IdUsuario { get; set; }
        public string NombreEmpresa { get; set; } = string.Empty;
        public string NombreRepresentante { get; set; } = string.Empty;
        public string? DescripcionEmpresa { get; set; }

        public Usuario? Usuario { get; set; }

        public Empresa(int idUsuario, string nombreEmpresa, string nombreRepresentante, string? descripcionEmpresa = null)
        {
            IdUsuario = idUsuario;
            NombreEmpresa = nombreEmpresa;
            NombreRepresentante = nombreRepresentante;
            DescripcionEmpresa = descripcionEmpresa;
        }

        public void Validate()
        {
            if (IdUsuario <= 0)
                throw new ValidationException("El Id del usuario debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(NombreEmpresa))
                throw new ValidationException("El nombre de la empresa no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(NombreRepresentante))
                throw new ValidationException("El nombre del representante no puede estar vacío.");
        }
    }
}
