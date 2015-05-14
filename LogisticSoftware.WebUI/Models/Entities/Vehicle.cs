using System;
using System.Collections.Generic;

namespace LogisticSoftware.WebUI.Models.Entities
{
    public class Vehicle
    {

        public int VehicleId { get; set; }

        public string RegistrationNumber { get; set; }
        public DateTime LastInspection { get; set; }
        public double LoadCapacity { get; set; }

        public string ModelName { get; set; }
        public virtual FuelType FuelType { get; set; }
    
        public virtual ICollection<ItemInSupply> ItemInSupply { get; set; }

        public override string ToString()
        {
            return RegistrationNumber + ", "
                + ModelName;
        }
    }
}
