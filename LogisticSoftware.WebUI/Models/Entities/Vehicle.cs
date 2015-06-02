using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Vehicles")]
    public class Vehicle
    {
        
        public int VehicleId { get; set; }

        [DisplayName("Реєстраційний номер")]
        [Required]
        public string RegistrationNumber { get; set; }

        [DisplayName("Модель автомобіля")]
        [Required]
        public string ModelName { get; set; }

        [DisplayName("Дата останнього тех. огляду")]
        [Required]
        public DateTime LastInspection { get; set; }

        [DisplayName("Максимальне навантаження")]
        [Required]
        public double WeightCapacity { get; set; }

        [DisplayName("Розмір багажного відділення")]
        [Required]
        public double TrunkSize { get; set; }

        [DisplayName("Прикріплений водій")]
        public Driver Driver { get; set; }
        [Key, ForeignKey("Driver")]
        public int DriverId { get; set; }

        [DisplayName("Прикріплений до гаража")]
        public Garage Garage { get; set; }

        [DisplayName("Тип пального")]
        public virtual FuelType FuelType { get; set; }
    
        public virtual ICollection<ItemInSupply> ItemInSupply { get; set; }
    }
}
