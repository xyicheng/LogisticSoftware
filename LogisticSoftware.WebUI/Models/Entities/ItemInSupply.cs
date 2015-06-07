using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public int ItemInSupplyId { get; set; }

        [DisplayName("Назва об'єкта поставки")]
        public string ItemName { get; set; }

        [DisplayName("Кількість об'єктів в упаковці")]
        public int ItemsQuantityInPack { get; set; }

        [DisplayName("Маса упаовки з об'єктами")]
        public double SingleItemWeight { get; set; }

        [DisplayName("Кількість упаовок в поставці")]
        public int NumberOfPackages { get; set; }

        [ForeignKey("FromPlaceId")]
        public virtual PlaceOnTheRoute From { get; set; }
        [Required]
        [DisplayName("Місце завантаження")]
        public int FromPlaceId { get; set; }

        [ForeignKey("ToPlaceId")]
        public virtual PlaceOnTheRoute To { get; set; }
        [Required]
        [DisplayName("Місце вивантаження")]
        public int ToPlaceId { get; set; }

        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }
        [DisplayName("Транспортний засіб")]
        public int VehicleId { get; set; }

    }
}