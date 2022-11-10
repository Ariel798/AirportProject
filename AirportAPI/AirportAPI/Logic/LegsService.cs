using Interfaces;
using Models;

namespace AirportAPI.Logic
{
    public class LegsService : ILegsService
    {
        public List<IAirportLeg> airportLegs = new List<IAirportLeg>();
        public LegsService()
        {
            StationStarter();
        }
        private void StationStarter()
        {
            var station1 = new AirportLeg { AirportLegId = 1 };
            var station2 = new AirportLeg { AirportLegId = 2 };
            var station3 = new AirportLeg { AirportLegId = 3 };
            var station4 = new AirportLeg { AirportLegId = 4 };
            var station5 = new AirportLeg { AirportLegId = 5 };
            var station6 = new AirportLeg { AirportLegId = 6 };
            var station7 = new AirportLeg { AirportLegId = 7 };
            var station8 = new AirportLeg { AirportLegId = 8 };
            airportLegs.Add(station1);
            airportLegs.Add(station2);
            airportLegs.Add(station3);
            airportLegs.Add(station4);
            airportLegs.Add(station5);
            airportLegs.Add(station6);
            airportLegs.Add(station7);
            airportLegs.Add(station8);
        }
        public IEnumerable<IAirportLeg> GetLegStatus()
        {
            return airportLegs.Select(l => new AirportLeg { AirportLegId = l.AirportLegId, Flight = l.Flight});
        }
        public IEnumerable<IAirportLeg> GetLegs()
        {
            return airportLegs;
        }
    }
}
