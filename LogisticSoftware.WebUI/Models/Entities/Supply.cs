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
        public string Target { get; set; }
        public DateTime Date { get; set; }
        
        public virtual ICollection<PlaceOnTheRoute> PlacesOnTheRoute { get; set; }
        

    }
}
