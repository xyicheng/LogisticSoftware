using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Places")]
    public class Place
    {
        
        public int PlaceId { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string NumberOfBuilding { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [InverseProperty("From")]
        public virtual ICollection<Route> WhenFrom { get; set; }

        [InverseProperty("To")]
        public virtual ICollection<Route> WhenTo { get; set; }

        public override string ToString()
        {
            return Region + " обл. "
                + District + " р-н. "
                + City + ", вул."
                + Street + ", "
                + NumberOfBuilding;
        }
    }
}
