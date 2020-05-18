using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//Name: Neil Hunter
//Project: DonaldsonMototrs
//Date : 18/05/20

namespace DonaldsonMotors.Models.SystemParts
{
    /// <summary>
    /// a class used to generate timeslots
    /// </summary>
    public class Slot
    {
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime date { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public string desc { get; set; }


    }
}