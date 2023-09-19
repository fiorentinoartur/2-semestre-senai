﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.Domains
{
    [Table(nameof(ComentariosEvento))]
    public class ComentariosEvento
    {
        [Key]
        public Guid IdComentarioEvento { get; set; }

        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage ="A Descricão é obrigatória")]
        public string? Descricao { get; set; }

        [Column(TypeName ="BIT")]
        [Required(ErrorMessage ="A informação de exibição é obrigatória")]
        public bool MyProperty { get; set; }

        //red.tabela Usuario = FK
        [Required(ErrorMessage = "Usuário obrigatório")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        //ref.tabela Evento = FK

        [Required(ErrorMessage = "Evento obrigatório")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }




    }
}
