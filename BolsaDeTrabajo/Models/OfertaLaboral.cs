using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaDeTrabajo.Models
{
    public class OfertaLaboral
    {
        public int IdOferta { get; set; }
        public int IdEmpresa { get; set; }

        public string TituloPuesto { get; set; } = string.Empty;
        public string DescripcionPuesto { get; set; } = string.Empty;
        public string? ConocimientoNecesarios { get; set; }
        public string PerfilAcademico { get; set; } = string.Empty;
        public string ExperienciaRequerida { get; set; } = string.Empty;
        public decimal SalarioMinimo { get; set; }
        public decimal SalarioMaximo { get; set; }
        public string ModalidadEmpleo { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaCierre { get; set; }
        public string EstadoOferta { get; set; } = string.Empty;

        public Empresa? Empresa { get; set; }

        public OfertaLaboral(
            int idEmpresa,
            string tituloPuesto,
            string descripcionPuesto,
            string perfilAcademico,
            string experienciaRequerida,
            decimal salarioMinimo,
            decimal salarioMaximo,
            string modalidadEmpleo,
            string ubicacion,
            DateTime fechaPublicacion,
            DateTime fechaCierre,
            string estadoOferta,
            string? conocimientoNecesarios = null)
        {
            IdEmpresa = idEmpresa;
            TituloPuesto = tituloPuesto;
            DescripcionPuesto = descripcionPuesto;
            ConocimientoNecesarios = conocimientoNecesarios;
            PerfilAcademico = perfilAcademico;
            ExperienciaRequerida = experienciaRequerida;
            SalarioMinimo = salarioMinimo;
            SalarioMaximo = salarioMaximo;
            ModalidadEmpleo = modalidadEmpleo;
            Ubicacion = ubicacion;
            FechaPublicacion = fechaPublicacion;
            FechaCierre = fechaCierre;
            EstadoOferta = estadoOferta;
        }

        public void Validate()
        {
            if (IdEmpresa <= 0)
                throw new ValidationException("El Id de la empresa debe ser mayor que 0.");

            if (string.IsNullOrWhiteSpace(TituloPuesto))
                throw new ValidationException("El título del puesto no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(DescripcionPuesto))
                throw new ValidationException("La descripción del puesto no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(PerfilAcademico))
                throw new ValidationException("El perfil académico no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(ExperienciaRequerida))
                throw new ValidationException("La experiencia requerida no puede estar vacía.");

            if (SalarioMinimo < 0)
                throw new ValidationException("El salario mínimo no puede ser negativo.");

            if (SalarioMaximo < SalarioMinimo)
                throw new ValidationException("El salario máximo no puede ser menor que el salario mínimo.");

            if (string.IsNullOrWhiteSpace(ModalidadEmpleo))
                throw new ValidationException("La modalidad de empleo no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(Ubicacion))
                throw new ValidationException("La ubicación no puede estar vacía.");

            if (FechaPublicacion == default) 
                throw new ValidationException("La fecha de publicación no es válida.");

            if (FechaCierre < FechaPublicacion)
                throw new ValidationException("La fecha de cierre no puede ser anterior a la fecha de publicación.");

            if (string.IsNullOrWhiteSpace(EstadoOferta))
                throw new ValidationException("El estado de la oferta no puede estar vacío.");
        }
    }
}
