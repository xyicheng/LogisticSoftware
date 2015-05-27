using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Categories")]
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    
        public virtual ICollection<Driver> Drivers { get; set; }

    }
}
