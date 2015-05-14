using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Routes")]   
    public class Route
    {
    
        public int RouteId { get; set; }
        public double Distance { get; set; }
        public string Description { get; set; }
    
        public virtual Place From { get; set; }
        public virtual Place To { get; set; }
        public virtual ICollection<Supply> Supply { get; set; }

        public override string ToString()
        {
            return From.City + ", " + From.Street + " " + From.NumberOfBuilding + " -> "
                + To.City + ", " + To.Street + " " + To.NumberOfBuilding;
        }
    }
}
