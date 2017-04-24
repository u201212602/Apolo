using System.ComponentModel.DataAnnotations;

namespace Apolo.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Usuario requerido")]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Contraseña requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }
    }
}