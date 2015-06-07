using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Призначення поставки")]
        [Required(ErrorMessage = "Призначення поставки є обов'язковим полем")]
        public string Target { get; set; }

        [DisplayName("Дата поставки")]
        [Required(ErrorMessage = "Дата поставки є обов'язковим полем")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Date { get; set; }

        public virtual ICollection<PlaceOnTheRoute> PlacesOnTheRoute { get; set; }


    }
}
