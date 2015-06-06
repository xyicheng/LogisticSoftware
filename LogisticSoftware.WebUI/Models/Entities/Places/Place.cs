using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities.Places
{
    [Table("Places")]
    public class Place : MapPoint
    {

        [Required(ErrorMessage = "Назва є обов'язковим полем")]
        [DisplayName("Назва")]
        public string PlaceName { get; set; }

        [Required(ErrorMessage = "Адреса є обов'язковим полем")]
        [DisplayName("Адреса")]
        public string Address { get; set; }

        [ScaffoldColumn(false)]
        [InverseProperty("From")]
        public virtual ICollection<Supply> WhenFrom { get; set; }

        [ScaffoldColumn(false)]
        [InverseProperty("To")]
        public virtual ICollection<Supply> WhenTo { get; set; }
    }
}
