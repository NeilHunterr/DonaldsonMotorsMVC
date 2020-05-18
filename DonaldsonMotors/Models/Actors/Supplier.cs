using DonaldsonMotors.Models.SystemParts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//Name: Neil Hunter
//Project: DonaldsonMototrs
//Date : 18/05/20

namespace DonaldsonMotors.Models.Actors
{
    /// <summary>
    /// class for suppliers information / out with scope
    /// </summary>
    public class Supplier
    {
        [Required]
        public string SupplierId { get; set; }
        [Required]
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }
        [Required]
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }
        [Required]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        [Required]
        [Display(Name = "Contact Email")]
        public string ContactEmail { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Postcode { get; set; }

        //nav props
        public List<Order> Orders { get; set; }
    }
}