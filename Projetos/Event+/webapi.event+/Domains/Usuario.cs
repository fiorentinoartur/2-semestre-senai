using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="Nome do usuário obrigatório!")]
        public string NomeUsuario { get; set; }  
        
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="Email do usuário obrigatório!")]
        public string Email { get; set; }

        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "Senha Obrigatória")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 60 caracteres")]
        public string Senha { get; set; }

        //ref.tabela TiposUsuario = FK
        [Required(ErrorMessage = "Informe o tipo do usuário!")]

        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TiposUsuario TipoUsuario { get; set; }
    }
}
