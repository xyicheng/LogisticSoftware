using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities.Places
{
    [Table("Places")]
    public class Place
    {
        
        public int PlaceId { get; set; }

        [Required(ErrorMessage = "Назва є обов'язковим полем")]
        [DisplayName("Назва")]
        public string PlaceName { get; set; }

        [Required(ErrorMessage = "Адреса є обов'язковим полем")]
        [DisplayName("Адреса")]
        public string Address { get; set; }

        [ScaffoldColumn(false)]
        [Required(ErrorMessage = "Географічні координати є обов'язковими")]
        [DisplayName("Широта")]
        public double Latitude { get; set; }

        [ScaffoldColumn(false)]
        [Required(ErrorMessage = " ")]
        [DisplayName("Довгота")]
        public double Longitude { get; set; }
    }
}
