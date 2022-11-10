

namespace Interfaces
{
    public interface IFlightRoute
    {
        IAirportService Airport { get; set; }
        public List<IAirportLeg> Legs { get; set; }
        IEnumerable<IAirportLeg> GetNextStation();
    }
}