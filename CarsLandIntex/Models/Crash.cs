﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsLandIntex.Models
{
    public class Crash
    {
        [Key]
        [Required]
        public int CRASH_ID { get; set; }

        [Required(ErrorMessage = "Please Choose a Date")]
        public DateTime? CRASH_DATETIME { get; set; }

        [Required(ErrorMessage = "Please Enter a Route")]
        public int? ROUTE { get; set; }

        [Required(ErrorMessage = "Milepoint Required. Please enter a valid number")]
        public double? MILEPOINT { get; set; }

        [Required(ErrorMessage = "Latitude Required. Please enter a valid number")]
        public double? LAT_UTM_Y { get; set; }

        [Required(ErrorMessage = "Longitude Required. Please enter a valid number")]
        public double? LONG_UTM_X { get; set; }

        [Required(ErrorMessage = "Please Enter a Main Road Name")]
        public string? MAIN_ROAD_NAME { get; set; }

        [Required(ErrorMessage = "Please Choose a City. If there is no city select 'OUTSIDE CITY LIMITS'")]
        public int? CITY_ID { get; set; }
        [ForeignKey("CITY_ID")]
        public City? CITY { get; set; }

        [Required(ErrorMessage = "Please Choose a County")]
        public int? COUNTY_ID { get; set; }
        [ForeignKey("COUNTY_ID")]
        public County? County { get; set; }

        [Required(ErrorMessage = "Please choose a crash severity")]
        public int? CRASH_SEVERITY_ID { get; set; }
        [ForeignKey("CRASH_SEVERITY_ID")]
        public Severity? Severity { get; set; }

        [Required]
        public int? WORK_ZONE_RELATED { get; set; }

        [Required]
        public int? PEDESTRIAN_INVOLVED { get; set; }

        [Required]
        public int? BICYCLIST_INVOLVED { get; set; }

        [Required]
        public int? MOTORCYCLE_INVOLVED { get; set; }

        [Required]
        public int? IMPROPER_RESTRAINT { get; set; }

        [Required]
        public int? UNRESTRAINED { get; set; }

        [Required]
        public int? DUI { get; set; }

        [Required]
        public int? INTERSECTION_RELATED { get; set; }

        [Required]
        public int? WILD_ANIMAL_RELATED { get; set; }

        [Required]
        public int? DOMESTIC_ANIMAL_RELATED { get; set; }

        [Required]
        public int? OVERTURN_ROLLOVER { get; set; }

        [Required]
        public int? COMMERCIAL_MOTOR_VEH_INVOLVED { get; set; }

        [Required]
        public int? TEENAGE_DRIVER_INVOLVED { get; set; }

        [Required]
        public int? OLDER_DRIVER_INVOLVED { get; set; }

        [Required]
        public int? NIGHT_DARK_CONDITION { get; set; }

        [Required]
        public int? SINGLE_VEHICLE { get; set; }

        [Required]
        public int? DISTRACTED_DRIVING { get; set; }

        [Required]
        public int? DROWSY_DRIVING { get; set; }

        [Required]
        public int? ROADWAY_DEPARTURE { get; set; }


        public long? month { get; set; }
        public long? hour { get; set; }
        public long? minute { get; set; }
        public string? weekday { get; set; }
        public int? year { get; set; }
        public int? may { get; set; }

        
    }
}
