using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Garages")]
    public class Garage : Place
    {
        [ScaffoldColumn(false)]
        public virtual ICollection<Vehicle> Vehicles { get; set; } 
    }
}