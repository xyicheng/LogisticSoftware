using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LogisticSoftware.WebUI.Models.Entities.Places
{
    [Table("MapPointsOnRoutes")]
    public class MapPointOnRoute
    {

        [Key]
        public int MapPointOnRouteId { get; set; }

        public virtual MapPoint MapPoint { get; set; }

        public int PointNumber { get; set; }

        public virtual ICollection<ItemInSupply> ItemsInSupply { get; set; }

        [ForeignKey("SupplyId")]
        public virtual Supply Supply { get; set; }
        public int SupplyId { get; set; }
    }
}