using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique=true)] //Cria um indice único
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="O campo de Email é obrigatório")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "O campo de Senha é obrigatório")]
        [StringLength(200,MinimumLength = 6, ErrorMessage = "A senha deve conter de 6 a 200 caracteres")]
        public  string? Senha { get; set; }

        //Referência de chave estrangeira

        [Required(ErrorMessage ="Tipo do usuário obrigatório")]
        public Guid IdTipoUsuario { get; set; }


        [ForeignKey("IdTipoUsuario")]
        public TiposUsuario? TiposUsuario { get; set; }
    }
}






















