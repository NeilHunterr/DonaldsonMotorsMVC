using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DonaldsonMotors.Models.SystemParts;

namespace DonaldsonMotors.Models.Objects
{
    public class Customer : User
    {
        [Required]
        [Display(Name = "Customer Type")]
        public CustomerType CustomerType { get; set; }

        //nav props

        [Required]
        public List<Vehicle> Vehicles { get; set; }
        [Required]
        public List<Booking> Bookings { get; set; }
    }

    public enum CustomerType
    {
        General,
        Corporate
    }
    
}