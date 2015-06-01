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
        [DisplayName("Id Користувавча")]
        public int UserId { get; set; }

        [Required]
        [DisplayName("Логін")]
        
        public string Login { get; set; }

        [Required]
        [DisplayName("П.І.Б.")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
    }
}
