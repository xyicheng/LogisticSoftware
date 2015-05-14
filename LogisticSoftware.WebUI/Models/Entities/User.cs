using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Users")]
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [DisplayName("Логін")]
        public string Login { get; set; }

        [Required]

        public string PasswordMd5 { get; set; }

        [Required]
        [DisplayName("Ім'я")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("По-батькові")]
        public string MiddleName { get; set; }

        [Required]
        [DisplayName("Прізвище")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Мобільний телефон")]
        public string MobilePhone { get; set; }

        [Required]
        [DisplayName("Дата народження")]
        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return Login + ", "
                + MobilePhone + ", "
                + DateOfBirth.ToString("dd.MM.yyyy");
        }
    }
}
