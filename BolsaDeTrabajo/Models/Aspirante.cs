using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class Aspirante
    {
        public int IdAspirante { get; set; }
        public int IdUsuario { get; set; }

        public string PrimerNombre { get; set; } = string.Empty;
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = string.Empty;
        public string? SegundoApellido { get; set; }
        public string? PuestoBusca { get; set; }

        // 🆕 NUEVOS CAMPOS AGREGADOS (sincronizados con la BD)
        public string? Genero { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? TipoDocumentoIdentidad { get; set; }
        public string? NumeroDocumentoIdentidad { get; set; }
        public string? Nit { get; set; }
        public string? Nup { get; set; }

        public Usuario? Usuario { get; set; }

        // Constructor actualizado con todos los campos
        public Aspirante(
            int idUsuario,
            string primerNombre,
            string primerApellido,
            string? segundoNombre = null,
            string? segundoApellido = null,
            string? puestoBusca = null,
            // 🆕 NUEVOS PARÁMETROS
            string? genero = null,
            DateTime? fechaNacimiento = null,
            string? tipoDocumentoIdentidad = null,
            string? numeroDocumentoIdentidad = null,
            string? nit = null,
            string? nup = null)
        {
            IdUsuario = idUsuario;
            PrimerNombre = primerNombre;
            PrimerApellido = primerApellido;
            SegundoNombre = segundoNombre;
            SegundoApellido = segundoApellido;
            PuestoBusca = puestoBusca;
            // 🆕 ASIGNAR NUEVOS CAMPOS
            Genero = genero;
            FechaNacimiento = fechaNacimiento;
            TipoDocumentoIdentidad = tipoDocumentoIdentidad;
            NumeroDocumentoIdentidad = numeroDocumentoIdentidad;
            Nit = nit;
            Nup = nup;
        }

        public void Validate()
        {
            if (IdUsuario <= 0)
                throw new ValidationException("El Id del usuario debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(PrimerNombre))
                throw new ValidationException("El primer nombre no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(PrimerApellido))
                throw new ValidationException("El primer apellido no puede estar vacío.");

            // 🆕 VALIDACIONES NUEVAS
            if (FechaNacimiento.HasValue && FechaNacimiento > DateTime.Now)
                throw new ValidationException("La fecha de nacimiento no puede ser futura.");

            if (FechaNacimiento.HasValue && DateTime.Now.Year - FechaNacimiento.Value.Year > 120)
                throw new ValidationException("La fecha de nacimiento no es válida.");

            // Validar tipo de documento si se proporciona número
            if (!string.IsNullOrEmpty(NumeroDocumentoIdentidad) && string.IsNullOrEmpty(TipoDocumentoIdentidad))
                throw new ValidationException("Si proporciona número de documento, debe especificar el tipo.");

            // Validar formato DUI salvadoreño básico
            if (TipoDocumentoIdentidad == "DUI" && !string.IsNullOrEmpty(NumeroDocumentoIdentidad))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(NumeroDocumentoIdentidad, @"^\d{8}-\d$"))
                    throw new ValidationException("El formato del DUI debe ser: 12345678-9");
            }

            // Validar formato NIT salvadoreño básico
            if (!string.IsNullOrEmpty(Nit))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(Nit, @"^\d{4}-\d{6}-\d{3}-\d$"))
                    throw new ValidationException("El formato del NIT debe ser: 1234-567890-123-4");
            }
        }
    }
}