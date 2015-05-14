using System.ComponentModel.DataAnnotations;

namespace LogisticSoftware.WebUI.Models
{

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Будь ласка введіль логін користувача")]
        [Display(Name = "Логін")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Будь ласка введіть пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    } 
}