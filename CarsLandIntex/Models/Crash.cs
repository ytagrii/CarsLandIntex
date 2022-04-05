using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsLandIntex.Models
{
    public class Crash
    {
        [Key]
        [Required]
        public int CRASH_ID { get; set; }

        [Required]
        public DateTime CRASH_DATETIME { get; set; }

        [Required]
        public int ROUTE { get; set; }

        [Required]
        public double MILEPOINT { get; set; }

        [Required]
        public string LAT_UTM_Y { get; set; }

        [Required]
        public string LONG_UTM_X { get; set; }

        [Required]
        public string MAIN_ROAD_NAME { get; set; }

        [Required]
        public int CITY_ID { get; set; }
        [ForeignKey("CITY_ID")]
        public string CITY { get; set; }

        [Required]
        public int COUNTY_ID { get; set; }
        [ForeignKey("COUNTY_ID")]
        public string COUNTY_NAME { get; set; }

        [Required]
        public int CRASH_SEVERITY_ID { get; set; }
        [ForeignKey("CRASH_SEVERITY_ID")]
        public Severity Severity { get; set; }

        [Required]
        public bool WORK_ZONE_RELATED { get; set; }

        [Required]
        public bool PEDESTRIAN_INVOLVED { get; set; }

        [Required]
        public bool BICYCLIST_INVOLVED { get; set; }

        [Required]
        public bool MOTORCYCLE_INVOLVED { get; set; }

        [Required]
        public bool IMPROPER_RESTRAINT { get; set; }

        [Required]
        public bool UNRESTRAINED { get; set; }

        [Required]
        public bool DUI { get; set; }

        [Required]
        public bool INTERSECTION_RELATED { get; set; }

        [Required]
        public bool WILD_ANIMAL_RELATED { get; set; }

        [Required]
        public bool DOMESTIC_ANIMAL_RELATED { get; set; }

        [Required]
        public bool OVERTURN_ROLLOVER { get; set; }

        [Required]
        public bool COMMERCIAL_MOTOR_VEH_INVOLVED { get; set; }

        [Required]
        public bool TEENAGE_DRIVER_INVOLVED { get; set; }

        [Required]
        public bool OLDER_DRIVER_INVOLVED { get; set; }

        [Required]
        public bool NIGHT_DARK_CONDITION { get; set; }

        [Required]
        public bool SINGLE_VEHICLE { get; set; }

        [Required]
        public bool DISTRACTED_DRIVING { get; set; }

        [Required]
        public bool DROWSY_DRIVING { get; set; }

        [Required]
        public bool ROADWAY_DEPARTURE { get; set; }



    }
}
