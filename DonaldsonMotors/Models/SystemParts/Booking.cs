using DonaldsonMotors.Models.Objects;
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
        public string BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public bool CheckIn { get; set; }
        public bool Cancelled { get; set; }
        public string CancelationReason { get; set; }
        public double EstimatedCost { get; set; }
        public double Deposit { get; set; }
        public bool Complete { get; set; }
        public double TotalCost { get; set; }

        //nav props
        public List<Job> Jobs { get; set; }

        [ForeignKey("Customer")]
        public string CustId { get; set; }
        public Customer Customer { get; set; }

    }
}