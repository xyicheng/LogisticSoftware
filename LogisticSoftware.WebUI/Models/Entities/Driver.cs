using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Drivers")]
    public class Driver
    {
        public int DriverId { get; set; }

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
        [DisplayName("Дата народдження")]
        public DateTime DateOfBirth { get; set; }


        [DisplayName("Наявні водійські категорії")]
        public virtual ICollection<Category> Categories { get; set; }
    }
}
