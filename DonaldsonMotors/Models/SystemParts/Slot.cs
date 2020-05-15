using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonaldsonMotors.Models.SystemParts
{
    public class Slot
    {
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime date { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public string desc { get; set; }


    }
}