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
    /// A class for staff information - inherting from applicationUser
    /// </summary>
    public class Staff : User
    {
        [Display(Name = "Highest Qualification")]
        public string HighestQualification { get; set; }
        [Display(Name = "National Insurance Nummber")]
        public string NationalInsuranceNumber { get; set; }
        [Display(Name = "Emergency Contact Name")]
        public string EmergencyContactName { get; set; }
        [Display(Name = "Emergency Contact Number")]
        public string EmergencyContactNumber { get; set; }
        [Display(Name = "Contract Type")]
        public ContractType ContractType { get; set; }
        [Display(Name = "Start Date")]
        public DateTime ContractStartDate { get; set; }
        [Display(Name = "Termination Date")]
        public DateTime? ContractEndDate { get; set; }

        //nav props

        public List<Booking> Jobs { get; set; }
    }

    public enum ContractType
    {
        FullTime,
        PartTime
    }
}