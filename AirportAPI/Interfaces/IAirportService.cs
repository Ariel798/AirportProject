

namespace Interfaces
{
    public interface IAirportService
    {
        Task FlightManager(IFlightLogic flight);
    }
}
