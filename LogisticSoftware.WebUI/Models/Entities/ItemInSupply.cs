using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("ItemsInSyplies")]
    public class ItemInSupply
    {
        public int ItemInSupplyId { get; set; }

        public int NumberOfItems { get; set; }
        public virtual Item Item { get; set; }
        
        public virtual Supply Supply { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }

        public override string ToString()
        {
            return Item + ", кількість: " + NumberOfItems;
        }
    }
}
