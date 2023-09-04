using System.ComponentModel.DataAnnotations;

namespace webapi.Filmes.manha.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "A senha deve conter de 3 à 20 caracteres!")]
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string Senha { get; set; }
        public Boolean Permissao { get; set; }
    }
}
