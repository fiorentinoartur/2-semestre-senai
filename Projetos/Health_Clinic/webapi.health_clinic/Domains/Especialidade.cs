using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.Domains
{
    [Table(nameof(Especialidade))]
    public class Especialidade
    {
        [Key]
        public Guid IdEspecialidade { get; set; } = Guid.NewGuid();

        [Column(TypeName ="Varchar(50)")]
        [Required(ErrorMessage ="O Titulo de Especialidade é obrigatório!!!")]
        public string Titulo { get; set; }
    }
}
