using Interfaces;

namespace Interfaces
{
    public interface IFlightLogic
    {
        int FlightId { get; set; }
        string? FlightName { get; set; }
        int PassangersCount { get; set; }
        IAirportLeg AirportLeg { get; set; }
        Target Target { get; set; }
        public bool CompletedProcess { get; set; }
        Task Start(IFlightRoute flightRoute, Action<FlightStationLog,IFlightLogic> action);
    }
}