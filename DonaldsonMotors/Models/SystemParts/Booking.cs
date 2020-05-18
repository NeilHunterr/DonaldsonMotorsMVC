using DonaldsonMotors.Models.Actors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DonaldsonMotors.Models.SystemParts
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Display(Name = "Date")]
        public DateTime BookingDate { get; set; }
        [Display(Name = "Checked In")]
        public bool CheckIn { get; set; }
        public bool Cancelled { get; set; }
        [Display(Name = "Cancelation Reason")]
        public string CancelationReason { get; set; }
        [Display(Name = "Estimated Cost")]
        public double EstimatedCost { get; set; }
        public double Deposit { get; set; }
        public bool Complete { get; set; }
        [Display(Name = "Total Cost")]
        public double TotalCost { get; set; }
        [Display(Name = "Service Type")]
        public ServiceType ServiceType { get; set; }
        [Display(Name = "Service Note")]
        public string ServiceNote { get; set; }


        [ForeignKey("Customer")]
        public string CustId { get; set; }
        public Customer Customer { get; set; }

        public List<PartUsed> PartsUsed { get; set; }


        [ForeignKey("Staff")]
        public string StaffId { get; set; }
        public Staff Staff { get; set; }


        [ForeignKey("Vehicle")]
        public string Registration { get; set; }
        public Vehicle Vehicle { get; set; }

    }

    public enum ServiceType
    {
        MOT,
        OilChange,
        TyreChange,
        Repair
    }
}