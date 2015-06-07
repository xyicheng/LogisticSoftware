using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities.Places
{
    [Table("PlacesOnTheRoute")]
    public class PlaceOnTheRoute : Place
    {
        public int NumberOnTheRoute { get; set; }

        [ScaffoldColumn(false)]
        [InverseProperty("From")]
        public virtual ICollection<ItemInSupply> ToLoad { get; set; }

        [ScaffoldColumn(false)]
        [InverseProperty("To")]
        public virtual ICollection<ItemInSupply> ToUnLoad { get; set; }
    }
}