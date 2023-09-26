using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.Domains
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique = true)]
    [Index(nameof(Nome), IsUnique = true)]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(20)")]
        [Required(ErrorMessage = "O CRM é Obrigatório")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "O CRM deve conter 6 dígitos")]
        public string? CRM { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "O Nome é Obrigatório")]
        public string? Nome { get; set; }

        //ref.tabela IdEspecialidade = FK
        [Required(ErrorMessage = "Informe a especialidade!")]
        public Guid? IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }

        //ref.tabela IdClinica = FK
        [Required(ErrorMessage = "Informe a Clinica!")]
        public Guid? IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }

        //ref.tabela Usuário = FK
        [Required(ErrorMessage ="Informe o Usuário!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
