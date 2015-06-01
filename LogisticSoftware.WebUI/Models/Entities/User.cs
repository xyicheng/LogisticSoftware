using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Web.Mvc;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Users")]
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Логін є обов'язковим полем")]
        [DisplayName("Логін")]
        [Index(IsUnique = true)]
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
