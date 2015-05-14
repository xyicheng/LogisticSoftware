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

        [Required]
        [DisplayName("Назва пального")]
        public string FuelName { get; set; }
    
        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public override string ToString()
        {
            return FuelName;
        }

        public FuelType()
        { }
    }
}
