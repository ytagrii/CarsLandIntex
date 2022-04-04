using System;
using System.Linq;

namespace CarsLandIntex.Models
{
    public interface ISeverityRepo
    {
        IQueryable<Severity> Severities { get; }
    }
}
