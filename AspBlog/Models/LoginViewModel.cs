using System.ComponentModel.DataAnnotations;

namespace AspBlog.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vyplňte uživatelské jméno")]
        [Display(Name = "Uživatelské jméno")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vyplňte heslo")]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "zapamatovat na tomto zařízení?")]
        public bool RememberMe { get; set; }
    }
}
