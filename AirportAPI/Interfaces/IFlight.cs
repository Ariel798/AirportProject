using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IFlight
    {
        int FlightId { get; set; }
        string? FlightName { get; set; }
        IFlightRoute FlightRoute { get; set; }
        string? Landing { get; set; }
        int PassangersCount { get; set; }
        string? TakeOff { get; set; }
        Target Target { get; set; }

        void Start(IFlightRoute flightRoute);
    }
}
