using DonaldsonMotors.Models.SystemParts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

//Name: Neil Hunter
//Project: DonaldsonMototrs
//Date : 18/05/20

namespace DonaldsonMotors.Models.Actors
{
    /// <summary>
    /// a class for customers vehicles information
    /// </summary>
    public class Vehicle
    {
        [Key]
        [Required]
        public string Registration { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Year")]
        public string ProductionYear { get; set; }
        [Required]
        [Display(Name = "MOT Due Date")]
        public DateTime MOTDue { get; set; }
        [Required]
        public double Mileage { get; set; }

        //nav props

        [Required]
        [Display(Name = "Service History")]
        public List<Booking> ServiceHistory { get; set; }

        [ForeignKey("Customer")]
        public string Id { get; set; }
        public Customer Customer { get; set; }

    }
}