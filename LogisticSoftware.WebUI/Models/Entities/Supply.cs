using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web.UI.WebControls;
using LogisticSoftware.WebUI.Models.Entities.Places;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Supplies")]
    public class Supply
    {
    
        public int SupplyId { get; set; }
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        
        public virtual Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }

        [ForeignKey("FromPlaceId")]
        
        public virtual Place From { get; set; }
        [Required]
        public int FromPlaceId { get; set; }

        [ForeignKey("ToPlaceId")]
        
        public virtual Place To { get; set; }
        [Required]
        public int ToPlaceId { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        

    }
}
