using System;
using System.ComponentModel.DataAnnotations;

namespace CarsLandIntex.Models
{
    public class Severity
    {
        [Key]
        [Required]
        public int CRASH_SEVERITY_ID { get; set; }

        public string DESCRIPTION { get; set; }
        
    }
}
