using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

//Name: Neil Hunter
//Project: DonaldsonMototrs
//Date : 18/05/20

namespace DonaldsonMotors.Models.SystemParts
{
    /// <summary>
    /// a class for the parts used on a single booking / out with scope
    /// </summary>
    public class PartUsed
    {
        [Key]
        [Required]
        public string PartUsedId { get; set; }
        [Required]
        public int Quantity { get; set; }

        //nav props
        [ForeignKey("Part")]
        public string PartId { get; set; }
        public Part Part { get; set; }

        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}