﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities.Places
{
    [Table("Places")]
    public class Place
    {
        
        public int PlaceId { get; set; }

        [Required(ErrorMessage = "Назва є обов'язковим полем")]
        [DisplayName("Назва")]
        public string PlaceName { get; set; }

        [Required(ErrorMessage = "Адреса є обов'язковим полем")]
        [DisplayName("Адреса")]
        public string Address { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        [DisplayName("Широта")]
        public double Latitude { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        [DisplayName("Довгота")]
        public double Longitude { get; set; }

        [ScaffoldColumn(false)]
        [InverseProperty("From")]
        public virtual ICollection<Supply> WhenFrom { get; set; }

        [ScaffoldColumn(false)]
        [InverseProperty("To")]
        public virtual ICollection<Supply> WhenTo { get; set; }
    }
}