using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.Domains
{
    [Table(nameof(PresencasConsulta))]
    public class PresencasConsulta
    {
        [Key]
        public Guid IdPresencaConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage ="A situação da Presença Consulta é obrigatória")]
        public string Situacao { get; set; }
    }
}
