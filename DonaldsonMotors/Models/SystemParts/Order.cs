using DonaldsonMotors.Models.Actors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DonaldsonMotors.Models.SystemParts
{
    /// <summary>
    /// A class for part orders /out with scope
    /// </summary>
    public class Order
    {
        [Key]
        public string OrderId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Arrived { get; set; }

        //nav props
        [ForeignKey("Part")]
        public string PartId { get; set; }
        public Part Part { get; set; }

        [ForeignKey("Supplier")]
        public string SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}