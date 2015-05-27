using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

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
        [DisplayName("П.І.Б.")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        [HiddenInput]
        public string PasswordMd5 { get; set; }

        
    }
}
