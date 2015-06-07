using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities.Places
{
    [Table("PlacesOnTheRoute")]
    public class PlaceOnTheRoute
    {
        public int PlaceOnTheRouteId { get; set; }

        public int NumberOnTheRoute { get; set; }

        [ForeignKey("PlaceId")]
        public virtual Place Place { get; set; }
        public int PlaceId { get; set; }

        [ForeignKey("SupplyId")]
        public virtual Supply Supply { get; set; }
        public int SupplyId { get; set; }

        [ScaffoldColumn(false)]
        [InverseProperty("From")]
        public virtual ICollection<ItemInSupply> ToLoad { get; set; }

        [ScaffoldColumn(false)]
        [InverseProperty("To")]
        public virtual ICollection<ItemInSupply> ToUnLoad { get; set; }
    }
}