using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Users")]
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Логін є обов'язковим полем")]
        [DisplayName("Логін")]
        [Index(IsUnique = true)]
        [StringLength(450)]
        public string Login { get; set; }

        [Required(ErrorMessage = "П.І.Б. є обов'язковим полем")]
        [DisplayName("П.І.Б.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пароль є обов'язковим полем")]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
    }
}
