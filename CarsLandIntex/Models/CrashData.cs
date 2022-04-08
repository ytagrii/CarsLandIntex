using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CarsLandIntex.Models
{
    public class CrashData
    {
        [Required]
        public long pedestrian_involved { get; set; }
        [Required]
        public long bicyclist_involved { get; set; }
        [Required]
        public long motorcycle_involved { get; set; }
        [Required]
        public long improper_restraint { get; set; }
        [Required]
        public long unrestrained { get; set; }
        [Required]
        public long dui { get; set; }
        [Required]
        public long intersection_related { get; set; }
        [Required]
        public long overturn_rollover { get; set; }
        [Required]
        public long older_driver_involved { get; set; }
        [Required]
        public long single_vehicle { get; set; }
        [Required]
        public long distracted_driving { get; set; }
        [Required]
        public long drowsy_driving { get; set; }
        [Required]
        public long roadway_departure { get; set; }
        [Required]
        public long month { get; set; }
        [Required]
        [Range(1, 24, ErrorMessage = "Hour must be a number between 0 and 23")]
        public long hour { get; set; }
        [Required]
        [Range(0, 59, ErrorMessage = "Minute must be a number between 0 and 59")]
        public long minute { get; set; }
        public long county_name_TOOELE { get; set; }
        public long county_name_WASHINGTON { get; set; }
        public long county_name_WEBER { get; set; }
        public long weekday_Saturday { get; set; }
        public long weekday_Sunday { get; set; }
        public long city_AMERICAN_FORK { get; set; }
        public long city_BLUE_CREEK { get; set; }
        public long city_BOULDER { get; set; }
        public long city_EMORY { get; set; }
        public long city_GARDEN_CITY { get; set; }
        public long city_GREEN_RIVER { get; set; }
        public long city_HARRISVILLE { get; set; }
        public long city_HIGHLAND { get; set; }
        public long city_HOLDEN { get; set; }
        public long city_HURRICANE { get; set; }
        public long city_LA_VERKIN { get; set; }
        public long city_LAYTON { get; set; }
        public long city_LYNN { get; set; }
        public long city_MAPLETON { get; set; }
        public long city_MOSIDA { get; set; }
        public long city_MOUNT_PLEASANT { get; set; }
        public long city_OGDEN { get; set; }
        public long city_OUTSIDE_CITY_LIMITS { get; set; }
        public long city_PROVO { get; set; }
        public long city_ROY { get; set; }
        public long city_SALT_LAKE_CITY { get; set; }
        public long city_SOUTH_OGDEN { get; set; }
        public long city_SPANISH_FORK { get; set; }
        public long city_ST_GEORGE { get; set; }
        public long city_SYRACUSE { get; set; }
        public long city_THOMPSON { get; set; }
        public long city_VIVIAN_PARK { get; set; }
        public long city_WANSHIP { get; set; }
        public long city_WEST_JORDAN { get; set; }
        [Required]
        public string county { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string weekday { get; set; }
        public Tensor<long> AsTensor()
        {
            long[] data = new long[]
                {
                pedestrian_involved, bicyclist_involved, motorcycle_involved, improper_restraint, unrestrained, dui, intersection_related,
                overturn_rollover, older_driver_involved, single_vehicle, distracted_driving, drowsy_driving,roadway_departure, month, hour, minute,
                county_name_TOOELE, county_name_WASHINGTON, county_name_WEBER, weekday_Saturday, weekday_Sunday, city_AMERICAN_FORK, city_BLUE_CREEK,
                city_BOULDER, city_EMORY, city_GARDEN_CITY, city_GREEN_RIVER, city_HARRISVILLE, city_HIGHLAND, city_HOLDEN, city_HURRICANE,city_LA_VERKIN,
                city_LAYTON, city_LYNN, city_MAPLETON, city_MOSIDA, city_MOUNT_PLEASANT,city_OGDEN,city_OUTSIDE_CITY_LIMITS,city_PROVO,city_ROY,
                city_SALT_LAKE_CITY, city_SOUTH_OGDEN, city_SPANISH_FORK, city_ST_GEORGE, city_SYRACUSE, city_THOMPSON,city_VIVIAN_PARK, city_WANSHIP,
                city_WEST_JORDAN
                };
            int[] dimensions = new int[] { 1, 50 };
            return new DenseTensor<long>(data, dimensions);
        }
        public void AttributeSetting(CrashData randomname)
        {
            PropertyInfo[] properties = typeof(CrashData).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.Name == randomname.county)
                {
                    property.SetValue(randomname, 1);
                }

                if (property.Name == randomname.city)
                {
                    property.SetValue(randomname, 1);
                }

                if (property.Name == randomname.weekday)
                {
                    property.SetValue(randomname, 1);
                }
            }

        }
        public void CreateCrashData(Crash c)
        {
            pedestrian_involved = Convert.ToInt64(c.PEDESTRIAN_INVOLVED);
            bicyclist_involved = Convert.ToInt64(c.BICYCLIST_INVOLVED);
            motorcycle_involved = Convert.ToInt64(c.MOTORCYCLE_INVOLVED);
            improper_restraint = Convert.ToInt64(c.IMPROPER_RESTRAINT);
            unrestrained = Convert.ToInt64(c.UNRESTRAINED);
            dui = Convert.ToInt64(c.DUI);
            overturn_rollover = Convert.ToInt64(c.OVERTURN_ROLLOVER);
            older_driver_involved = Convert.ToInt64(c.OLDER_DRIVER_INVOLVED);
            single_vehicle = Convert.ToInt64(c.SINGLE_VEHICLE);
            distracted_driving = Convert.ToInt64(c.DISTRACTED_DRIVING);
            drowsy_driving = Convert.ToInt64(c.DROWSY_DRIVING);
            roadway_departure = Convert.ToInt64(c.ROADWAY_DEPARTURE);
            month = Convert.ToInt64(c.month);
            hour = Convert.ToInt64(c.hour);
            minute = Convert.ToInt64(c.minute);

            string cityParsed = c.CITY.CITY.ToString().ToUpper().Replace(" ", "_");
            cityParsed = "city_" + cityParsed;

            string countyParsed = c.County.ToString().ToUpper().Replace(" ", "_");
            countyParsed = "county_" + countyParsed;

            PropertyInfo[] properties = typeof(CrashData).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.Name == countyParsed)
                {
                    property.SetValue(countyParsed, 1);
                }

                if (property.Name == cityParsed)
                {
                    property.SetValue(cityParsed, 1);
                }

                if (property.Name == c.weekday)
                {
                    property.SetValue(c.weekday, 1);
                }

            }
        }
    }
}