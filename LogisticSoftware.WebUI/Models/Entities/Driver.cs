using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Drivers")]
    public class Driver : User
    {
        [DisplayName("Наявні водійські категорії")]
        public virtual ICollection<Category> Categories { get; set; }
    }
}
