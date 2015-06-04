using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        public virtual Place From { get; set; }
        public virtual Place To { get; set; }

        public virtual ICollection<Item> Items { get; set; }

    }
}
