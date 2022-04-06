using System;
namespace CarsLandIntex.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalCrashes { get; set; }
        public int CrashesPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCrashes / CrashesPerPage);
    }
}
