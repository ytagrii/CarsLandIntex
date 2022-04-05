using System;
using System.Linq;

namespace CarsLandIntex.Models
{
    public interface ICityRepo
    {
        IQueryable<City> Cities { get; }
    }
}
