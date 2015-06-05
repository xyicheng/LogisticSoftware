using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LogisticSoftware.WebUI.Models.Entities
{
    public class ItemInSupply
    {
        [Key, ForeignKey("SupplyId")]
        public Supply Supply { get; set; }
        [Key]
        public int SupplyId { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }
        public int ItemId { get; set; }

        public int Quantity { get; set; }
    }
}