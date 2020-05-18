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
        public DateTime BookingDate { get; set; }
        public bool CheckIn { get; set; }
        public bool Cancelled { get; set; }
        public string CancelationReason { get; set; }
        public double EstimatedCost { get; set; }
        public double Deposit { get; set; }
        public bool Complete { get; set; }
        public double TotalCost { get; set; }
        public ServiceType ServiceType { get; set; }
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