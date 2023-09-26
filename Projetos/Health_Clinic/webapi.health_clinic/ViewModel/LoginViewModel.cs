using System.ComponentModel.DataAnnotations;

namespace webapi.health_clinic.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email obrigatória")]
        public string Email { get; set; } 
        
        [Required(ErrorMessage ="Senha obrigatória")]
        public string Senha { get; set; }
    }
}
