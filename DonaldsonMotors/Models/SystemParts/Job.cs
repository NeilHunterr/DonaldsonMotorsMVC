using DonaldsonMotors.Models.Actors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DonaldsonMotors.Models.SystemParts
{
    public class Job
    {
        [Key]
        [Required]
        public string JobId { get; set; }
        [Required]
        [Display(Name = "Service Type")]
        public ServiceType ServiceType { get; set; }
        [Display(Name = "Repair Description")]
        public string RepairDesc { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public bool Complete { get; set; }

        //nav props

        public List<PartUsed> PartsUsed { get; set; }

        [ForeignKey("Staff")]
        public string StaffId { get; set; }
        public Staff Staff { get; set; }

        [ForeignKey("Booking")]
        public string BookingId { get; set; }
        public Booking Booking { get; set; }
    }
    
    public enum ServiceType
    {
        MOT,
        OilChange,
        TyreChange,
        Repair
    }
}