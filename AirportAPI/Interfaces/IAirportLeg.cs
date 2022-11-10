
namespace Interfaces
{
    public interface IAirportLeg
    {
        int AirportLegId { get; set; }
        IFlightLogic Flight { get; set; }
        Task Enter(IFlightLogic flight);
        Task ExitStation(IFlightLogic flight);
    }
}