using System.ComponentModel.DataAnnotations;

namespace webapi.Filmes.manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade(Tabela) Genero
    /// </summary>
    public class GeneroDomains
    {
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "O nome do gênero é obrigatório")]
        public string Nome { get; set; }    
    }
}
