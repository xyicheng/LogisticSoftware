using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LogisticSoftware.WebUI.Models.Entities.Places
{
    [Table("MapPoints")]
    public class MapPoint
    {

        public int MapPointId { get; set; }

        [ScaffoldColumn(false)]
        [Required(ErrorMessage = "Географічні координати є обов'язковими")]
        [DisplayName("Широта")]
        public double Latitude { get; set; }

        [ScaffoldColumn(false)]
        [Required(ErrorMessage = " ")]
        [DisplayName("Довгота")]
        public double Longitude { get; set; }

        public virtual ICollection<MapPointOnRoute> MapPointOnRoutes { get; set; } 
    }
}