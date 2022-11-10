using AirportAPI.Services;
using Interfaces;
using Repositories.Repositories;
using Unity;

namespace AirportAPI.Logic.FlightRoute
{
    public class FlightRoute : IFlightRoute
    {
        private FlightRepository flightRepository;

        public List<IAirportLeg> Legs {get;set;}
        public FlightRoute()
        {
            Legs = new List<IAirportLeg>();
        }
        public FlightRoute(FlightRepository flightRepository)
        {
            this.flightRepository = flightRepository;
        }

        public IAirportService Airport { get; set; }

        public IEnumerable<IAirportLeg> GetNextStation()
        {foreach (IAirportLeg airportLeg in Legs){yield return airportLeg;}}
    }
}