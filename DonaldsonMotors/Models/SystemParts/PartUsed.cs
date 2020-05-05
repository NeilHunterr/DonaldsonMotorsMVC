using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DonaldsonMotors.Models.SystemParts
{
    public class PartUsed
    {
        [Key]
        [Required]
        public string PartUsedId { get; set; }
        [Required]
        public int Quantity { get; set; }

        //nav props
        [ForeignKey("Part")]
        public string PartId { get; set; }
        public Part Part { get; set; }

        [ForeignKey("Job")]
        public string JobId { get; set; }
        public Job Job { get; set; }
    }
}