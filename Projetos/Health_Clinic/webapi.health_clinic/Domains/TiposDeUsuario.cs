using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.Domains
{
    [Table(nameof(TiposDeUsuario))]
    [Index(nameof(Titulo), IsUnique = true)]
    public class TiposDeUsuario
    {
        [Key]
        public Guid IdTiposDeUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(50)")]
        [Required(ErrorMessage ="O Título de Tipo de Usuário é obrigatório")]
        public string? Titulo { get; set; }
    }
}
