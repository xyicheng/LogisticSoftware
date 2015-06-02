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

        [Required(ErrorMessage = "П.І.Б. є обов'язковим полем")]
        [DisplayName("Ім'я")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Дата народдження")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Прикріплений ТЗ")]
        public Vehicle Vehicle { get; set; }

        [DisplayName("Наявні водійські категорії")]
        public virtual ICollection<Category> Categories { get; set; }
    }
}
