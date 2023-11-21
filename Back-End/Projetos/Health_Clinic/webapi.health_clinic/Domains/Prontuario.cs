using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.Domains
{
    [Table(nameof(Prontuario))]
    public class Prontuario
    {
        [Key]
        public Guid IdProntuario { get; set; } = Guid.NewGuid();


        [Column(TypeName = "VARCHAR(256)")]
        [Required(ErrorMessage ="A descrição é obrigatória")]
        public string? Descricao { get; set; }

        //ref.tabela Usuário = FK
        [Required(ErrorMessage = "Informe o Usuário!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; } 
        
        //ref.tabela Consulta = FK
        [Required(ErrorMessage = "Informe a Consutla!!!")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }
    }
}
