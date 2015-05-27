using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Vehicles")]
    public class Vehicle
    {

        public int VehicleId { get; set; }

        [DisplayName("Реєстраційний номер")]
        public string RegistrationNumber { get; set; }

        [DisplayName("Модель автомобіля")]
        public string ModelName { get; set; }

        [DisplayName("Дата останнього тех. огляду")]
        public DateTime LastInspection { get; set; }

        [DisplayName("Максимальне навантаження")]
        public double WeightCapacity { get; set; }

        [DisplayName("Розмір багажного відділення")]
        public double TrunkSize { get; set; }

        [DisplayName("Прикріплений водій")]
        public Driver Driver { get; set; }

        [DisplayName("Тип пального")]
        public virtual FuelType FuelType { get; set; }
    
        public virtual ICollection<ItemInSupply> ItemInSupply { get; set; }
    }
}
