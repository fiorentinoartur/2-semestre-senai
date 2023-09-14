using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace webapi.inlock.codeFirst.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Nome do jogo é obrigatório!")]
        public string ?Nome { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição do jogo é obrigatória!")]
        public string ?Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data lancamento obrigatório!")]
        public DateTime Datalancamento { get; set; }

        [Column(TypeName = "Decimal(4,2)")]
        [Required(ErrorMessage = "Preço do jogo é obrigatório")]
        public Decimal Preco { get; set; }

        public Guid IdEstudio { get; set; }

        //Referência da chave estrangeira (Tabela de Estúdio)

        [Required(ErrorMessage = "Informe o estúdio que produziu o jogo")]
        [ForeignKey("IdEstudio")]
        public Estudio ?Estudio { get; set; }
    }
}
