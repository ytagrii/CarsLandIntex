using System;
namespace CarsLandIntex.Models
{
    public class Filtering
    {
        
        public int? county { get; set; }
        public string? city { get; set; }
        public string? weekday { get; set; }
        public int? year { get; set; }
        public int? month { get; set; }
        public int? severity { get; set; }
    }
}
