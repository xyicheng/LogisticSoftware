using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("OfficeManagers")]
    public class OfficeManager : User
    {  
        public virtual ICollection<Supply> Supply { get; set; }
    }
}
