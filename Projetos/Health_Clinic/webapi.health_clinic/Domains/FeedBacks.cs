using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.health_clinic.Domains
{
    [Table(nameof(FeedBacks))]
    public class FeedBacks
    {
        [Key]
        public Guid IdFeedBacks { get; set; } = Guid.NewGuid();

        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage = "A Descrição é obrigatória")]
        public string? Descricao { get; set; }
        //ref.tabela IdConsulta = FK
        [Required(ErrorMessage = "Informe a Consulta!")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }
    }
}
