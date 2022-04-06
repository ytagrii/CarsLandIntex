using System;
using System.Linq;

namespace CarsLandIntex.Models
{
    public interface ICityRepo
    {
        IQueryable<City> cities { get; }
    }
}
