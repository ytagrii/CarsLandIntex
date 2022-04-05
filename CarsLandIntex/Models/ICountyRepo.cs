using System;
using System.Linq;

namespace CarsLandIntex.Models
{
    public interface ICountyRepo
    {
        IQueryable<County> Counties { get; }
    }
}
