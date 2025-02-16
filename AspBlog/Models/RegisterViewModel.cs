using System.ComponentModel.DataAnnotations;

namespace AspBlog.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vyplňte uživatelské jméno")]
        [Display(Name = "Uživatelské jméno")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Vyplňte heslo")]
        [StringLength(100, ErrorMessage = "{0} musí mít délku alespoň {2} a nejvíc {1} znaků", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo (musí obsahovat malé velké písmeno, číslo a nealfanumerický znak)")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Vyplňte heslo")]
        [DataType(DataType.Password)]
        [Display(Name = "Potvrzení hesla")]
        [Compare(nameof(Password), ErrorMessage = "Zadaná hesla se neshodují")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
