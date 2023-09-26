using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.health_clinic.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A Data é obrigatória!")]
        public DateTime Data { get; set; }
       
        
        //ref.tabela IdProntuario = FK
        [Required(ErrorMessage = "Informe o Prontuário!")]
        public Guid IdProntuario{ get; set; }

        [ForeignKey(nameof(IdProntuario))]
        public Prontuario? Prontuario { get; set; }   
        
        //ref.tabela IdMedico = FK
        [Required(ErrorMessage = "Informe o Médico!")]
        public Guid IdMedico{ get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }

        //ref.tabela IdPresencaConsulta = FK
        [Required(ErrorMessage = "Informe a Presenca da Consulta!")]
        public Guid IdPresencaConsulta{ get; set; }

        [ForeignKey(nameof(IdPresencaConsulta))]
        public PresencasConsulta? PresencaConsulta { get; set; } 
        
        //ref.tabela IdPaciente = FK
        [Required(ErrorMessage = "Informe o Paciente!")]
        public Guid IdPaciente{ get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        //ref.tabela IdClinica = FK
        [Required(ErrorMessage = "Informe a Clinica!")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }  
        
    }
}
