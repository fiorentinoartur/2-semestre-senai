using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.Domains
{
    [Table(nameof(Evento))]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data do evento obrigatória")]
        public DateTime DataEvento { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do evento obrigatória")]
        public string? NomeEvento { get; set; } 
        
        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descricao do evento obrigatória")]
        public string? Descricao { get; set; }

        //ref.tabela  TiposEvento = FK
        [Required(ErrorMessage = "O tipo do evento é obrigatório!")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]
        public TiposEvento? TipoEvento { get; set; }

        //ref.tabela Instituição
        [Required(ErrorMessage = "Instituição obrigatória")]
        public Guid IdInstituicao { get; set; }

        [ForeignKey(nameof(IdInstituicao))]
        public Instituicao? Instituicao { get; set; }


    }
}
