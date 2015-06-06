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

        public virtual MapPointOnRoute MapPointOnRoute { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public virtual Item Item { get; set; }

        [Key, ForeignKey("Item")]
        public int ItemId { get; set; }
    }
}