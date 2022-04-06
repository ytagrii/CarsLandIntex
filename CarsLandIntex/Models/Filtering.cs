using System;
namespace CarsLandIntex.Models
{
    public class Filtering
    {
        public int county { get; set; }
        public string city { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int severity { get; set; }
    }
}
