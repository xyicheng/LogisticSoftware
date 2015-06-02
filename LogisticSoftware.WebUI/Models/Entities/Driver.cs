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
        [DisplayName("П.І.Б.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Дата народження є обов'язковим полем")]
        [DisplayName("Дата народдження")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Прикріплені ТЗ")]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
