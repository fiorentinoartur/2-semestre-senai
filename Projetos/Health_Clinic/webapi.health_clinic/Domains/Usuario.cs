using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.Domains
{
    [Table(nameof(Usuario))]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(256)")]
        [Required(ErrorMessage = "O Email é obrigatório")]
        public string Email { get; set; }


        [Column(TypeName =  "CHAR(60)")]
        [Required(ErrorMessage = "A senha  é obrigatória")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha dve conter de 6 a 60 caracteres!!!")]
        public string Senha { get; set; }
    }
}
