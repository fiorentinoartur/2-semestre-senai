using System.ComponentModel.DataAnnotations;

namespace webapi.Filmes.manha.Domains
{
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        [Required(ErrorMessage = "O título do filme é obrigatório")]
        public string Titulo { get; set;}

        public int IdGenero { get; set; }
        public GeneroDomains Genero { get; set; }
    }
}
