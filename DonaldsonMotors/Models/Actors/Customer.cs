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

//Name: Neil Hunter
//Project: DonaldsonMototrs
//Date : 18/05/20

namespace DonaldsonMotors.Models.Actors
{
    /// <summary>
    /// A Class of customer information - inheriting for applicationUser
    /// </summary>
    public class Customer : User
    {
        [Display(Name = "Customer Type")]
        public CustomerType CustomerType { get; set; }

        //nav props
        public List<Vehicle> Vehicles { get; set; }
        public List<Booking> Bookings { get; set; }
    }

    /// <summary>
    /// enum of types of customers
    /// </summary>
    public enum CustomerType
    {
        General,
        Corporate
    }
    
}