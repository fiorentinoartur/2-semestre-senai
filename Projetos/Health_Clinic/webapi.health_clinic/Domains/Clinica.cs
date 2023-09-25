using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health_clinic.Domains
{
    [Table(nameof(Clinica))]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(50)")]
        [Required(ErrorMessage = "O Nome Fantasia da clínica é Obrigatório")]
        public string NomeFantasia { get; set; }

        [Column(TypeName ="CHAR(14)")]
        [Required(ErrorMessage = "O CNPJ é obrigatório!!!")]
        [StringLength(14)]
        public string CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(256)")]
        [Required(ErrorMessage = "O endereço é obrigatório!!!")]
        public string Endereco { get; set; }


        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "O Funcionamento é obrigatório!!!")]
        public string Funcionamento { get; set; }


        [Column(TypeName = "VARCHAR(256)")]
        [Required(ErrorMessage = "A razão social é obrigatória!!!")]
        public string RazaoSocial { get; set; }
    }
}
