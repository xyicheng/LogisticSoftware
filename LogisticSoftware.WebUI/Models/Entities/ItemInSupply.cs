using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using LogisticSoftware.WebUI.Models.Entities.Places;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("ItemsInSupply")]
    public class ItemInSupply
    {

        [ForeignKey("FromPlaceId")]
        public virtual PlaceOnTheRoute From { get; set; }
        [Required]
        public int FromPlaceId { get; set; }

        [ForeignKey("ToPlaceId")]
        public virtual PlaceOnTheRoute To { get; set; }
        [Required]
        public int ToPlaceId { get; set; }

        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }

        
        public virtual Item Item { get; set; }
        [Key, ForeignKey("Item")]
        public int ItemId { get; set; }
    }
}