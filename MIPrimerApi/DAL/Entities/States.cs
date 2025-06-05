using System.ComponentModel.DataAnnotations;

namespace MIPrimerApi.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado/Departamento")] 
        [MaxLength(50, ErrorMessage = "El campo {0} debe de tener maximo {1} caracteres.")] 
        [Required(ErrorMessage = "es campo {0} es obligatorio")]  //campo obligatorio
        public String Name { get; set; }

        // asi es como relacionamos 2 tablas con EF core:
        [Display(Name = "Pais")]
        public Country? Country { get; set; }

        //FK
        [Display(Name = "Id Pais")]
        public Guid CountryId { get; set; }

    }
}