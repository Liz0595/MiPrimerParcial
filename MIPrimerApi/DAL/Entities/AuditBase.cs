using System.ComponentModel.DataAnnotations;

namespace MIPrimerApi.DAL.Entities
{
    public class AuditBase
    {
        [Key]
        [Required]
        public virtual Guid Id { get; set; } // Pk de todas las tablas

        public virtual DateTime? CreatedDate { get; set; } //Para guardar todo registro nuevo con su date

        public virtual DateTime? ModifiedDate { get; set; } //Para guardar todo registro que se modificó con su date
    }
}
