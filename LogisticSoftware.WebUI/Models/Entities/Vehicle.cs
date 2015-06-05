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
        [Key]
        public int VehicleId { get; set; }

        [DisplayName("Реєстраційний номер")]
        [Required(ErrorMessage = "Реєстраційний номер є обов'язковим полем")]
        public string RegistrationNumber { get; set; }

        [DisplayName("Модель автомобіля")]
        [Required(ErrorMessage = "Модель автомобіля є обов'язковим полем")]
        public string ModelName { get; set; }

        [DisplayName("Дата останнього тех. огляду")]
        [Required(ErrorMessage = "Дата останнього тех. огляду є обов'язковим полем")]
        public DateTime LastInspection { get; set; }

        [DisplayName("Максимальне навантаження (кг)")]
        [Required(ErrorMessage = "Максимальне навантаження є обов'язковим полем")]
        public double WeightCapacity { get; set; }

        [DisplayName("Розмір багажного відділення (л)")]
        [Required(ErrorMessage = "Розмір багажного відділення є обов'язковим полем")]
        public double TrunkSize { get; set; }

        
        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }
        [DisplayName("Прикріплений водій")]
        public int DriverId { get; set; }

        
        [ForeignKey("PlaceId")]
        public virtual Garage Garage { get; set; }
        [DisplayName("Прикріплений до гаража")]
        public int PlaceId { get; set; }

        
        [ForeignKey("FuelTypeId")]
        public virtual FuelType FuelType { get; set; }
        [DisplayName("Тип пального")]
        public int FuelTypeId { get; set; }
    }
}
