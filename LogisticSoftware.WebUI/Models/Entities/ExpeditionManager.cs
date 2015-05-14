using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("ExpeditionManagers")]
    public class ExpeditionManager : User
    {
        public virtual ICollection<Supply> Supply { get; set; }
    }
}
