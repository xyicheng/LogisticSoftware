using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("FuelTypes")]
    public class FuelType
    {
        public int FuelTypeId { get; set; }

        [Required(ErrorMessage = "Назва пального є обов'язковим полем")]
        [DisplayName("Назва пального")]
        public string FuelName { get; set; }
    
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
