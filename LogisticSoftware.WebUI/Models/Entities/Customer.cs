using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Customers")]
    public class Customer : Place
    {
        [Required]
        [DisplayName("Клієнт")]
        public string CustomerName { get; set; }
    }
}