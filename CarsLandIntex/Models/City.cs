using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsLandIntex.Models
{
    public class City
    {
        [Key]
        [Required]
        public int CITY_ID { get; set; }
        [Required]
        public string CITY { get; set; }
    
    }
}
