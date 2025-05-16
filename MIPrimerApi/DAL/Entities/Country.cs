using System.ComponentModel.DataAnnotations;

namespace MIPrimerApi.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "Pais")]
        [MaxLength(50, ErrorMessage = "El campo {0} del país debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = string.Empty; // Nombre del país
        public string? Currency { get; set; } // Moneda del país 
       
    }
}
