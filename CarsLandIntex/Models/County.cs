using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsLandIntex.Models
{
    public class County
    {
        [Key]
        [Required]
        public int COUNTY_ID { get; set; }
        [Required]
        public string COUNTY_NAME { get; set; }
    }
}
