using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Items")]
    public class Item
    {
    
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int NumberOfItems { get; set; }

        
        public double SingleItemWeight { get; set; }

        public int ItemsQuantityInPack { get; set; }

        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
