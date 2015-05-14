using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Supplies")]
    public class Supply
    {
    
        public int SupplyId { get; set; }
        public decimal SupplieCost { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
    
        public virtual ExpeditionManager ExpeditionManager { get; set; }
        public virtual ICollection<ItemInSupply> ItemInSupply { get; set; }
        public virtual OfficeManager OfficeManager { get; set; }
        public virtual Route Route { get; set; }

        public override string ToString()
        {
            return BeginTime.ToString("dd.MM.yyyy") + ":" + ExpeditionManager + ":" + Route;
        }

    }
}
