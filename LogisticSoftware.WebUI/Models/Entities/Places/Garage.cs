using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities.Places
{
    [Table("Garages")]
    public class Garage : Place
    {
        [ScaffoldColumn(false)]
        public virtual ICollection<Vehicle> Vehicles { get; set; } 
    }
}