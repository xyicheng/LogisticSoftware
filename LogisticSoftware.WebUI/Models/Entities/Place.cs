using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Places")]
    public class Place
    {
        
        public int PlaceId { get; set; }

        [Required(ErrorMessage = "Область є обов'язковим полем")]
        [DisplayName("Область")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Район є обов'язковим полем")]
        [DisplayName("Район")]
        public string District { get; set; }

        [Required(ErrorMessage = "Місто є обов'язковим полем")]
        [DisplayName("Місто")]
        public string City { get; set; }

        [Required(ErrorMessage = "Вулиця є обов'язковим полем")]
        [DisplayName("Вулиця")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Номер будівлі є обов'язковим полем")]
        [DisplayName("Номер будівлі")]
        public string NumberOfBuilding { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        [DisplayName("Широта")]
        public double Latitude { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        [DisplayName("Довгота")]
        public double Longitude { get; set; }

        [ScaffoldColumn(false)]
        [InverseProperty("From")]
        public virtual ICollection<Route> WhenFrom { get; set; }

        [ScaffoldColumn(false)]
        [InverseProperty("To")]
        public virtual ICollection<Route> WhenTo { get; set; }
    }
}
