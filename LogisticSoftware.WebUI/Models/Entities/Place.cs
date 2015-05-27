using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Places")]
    public class Place
    {
        
        public int PlaceId { get; set; }

        [Required]
        [DisplayName("Область")]
        public string Region { get; set; }

        [Required]
        [DisplayName("Район")]
        public string District { get; set; }

        [Required]
        [DisplayName("Місто")]
        public string City { get; set; }

        [Required]
        [DisplayName("Вулиця")]
        public string Street { get; set; }

        [Required]
        [DisplayName("Номер будівлі")]
        public string NumberOfBuilding { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        [HiddenInput]
        [DisplayName("Широта")]
        public double Latitude { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        [HiddenInput]
        [DisplayName("Довгота")]
        public double Longitude { get; set; }

        [InverseProperty("From")]
        public virtual ICollection<Route> WhenFrom { get; set; }

        [InverseProperty("To")]
        public virtual ICollection<Route> WhenTo { get; set; }
    }
}
