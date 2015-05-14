using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Items")]
    public class Item
    {
    
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double Weight { get; set; }
        public double ItemSizeX { get; set; }
        public double ItemSizeY { get; set; }
        public double ItemSizeZ { get; set; }
    
        public virtual ICollection<ItemInSupply> ItemInSupply { get; set; }

        public override string ToString()
        {
            return ItemName;
        }

    }
}
