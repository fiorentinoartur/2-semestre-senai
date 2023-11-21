using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace webapi.health_clinic.Domains
{
    [Table(nameof(Paciente))]
    [Index(nameof(CPF), IsUnique = true)]
    [Index(nameof(Nome), IsUnique = true)]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(60)")]
        [Required(ErrorMessage ="O nome é obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName ="CHAR(11)")]
        [Required(ErrorMessage = "O CPF é obrigatório!")]
        [StringLength(11,MinimumLength =11, ErrorMessage = "O CPF deve conter 11 dígitos")]
        public string? CPF { get; set; }

        //ref.tabela Usuário = FK
        [Required(ErrorMessage = "Informe o Usuário!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
