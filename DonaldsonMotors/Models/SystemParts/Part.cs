using DonaldsonMotors.Models.Actors;
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
    /// a class for parts used on bookings / out with scope
    /// </summary>
    public class Part
    {
        [Key]
        [Required]
        public string PartId { get; set; }
        [Required]
        [Display(Name = "Part Name")]
        public string PartName { get; set; }
        [Required]
        [Display(Name = "Part Description")]
        public string PartDesc { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public int Quatity { get; set; }
        [Required]
        public int MaxQuatity { get; set; }
        [Required]
        public string Demand { get; set; }
        [Required]
        public int ReorderQuantity { get; set; }
        [Required]
        public int QuantityOnOrder { get; set; }

        //nav props
        [ForeignKey("Supplier")]
        public string SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public List<Order> Orders { get; set; }
        public List<PartUsed> PartsUsed { get; set; }
    }
}