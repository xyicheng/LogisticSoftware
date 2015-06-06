using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("ItemsInSupply")]
    public class ItemInSupply
    {

        

        public virtual Supply Supply { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public virtual Item Item { get; set; }

        [Key, ForeignKey("Item")]
        public int ItemId { get; set; }
    }
}