using AirportAPI.Logic;
using AirportAPI.Logic.FlightRoute;
using Interfaces;
using Models;
using Repositories.Repositories;

namespace AirportAPI.Services
{
    public class AirportService : IAirportService
    {
        private FlightRepository _flightRepository;

        private readonly List<IFlightLogic> flights = new List<IFlightLogic>();
        ILegsService legService;
        public Action<FlightStationLog, IFlightLogic> ActionEvent { get; set; }
        public AirportService(FlightRepository flightRepository, ILegsService legService)
        {
            _flightRepository = flightRepository;
            this.legService = legService;
            ActionEvent += CreateEvent;
        }

        private void CreateEvent(FlightStationLog obj, IFlightLogic flightLogic)
        {
            var log = GenerateFlightEntity(flightLogic);
            if (flightLogic.CompletedProcess)
                _flightRepository.CreateEvent(obj, log);
            else
                _flightRepository.CreateEvent(obj,null);
        }

        public Task FlightManager(IFlightLogic flight)
        {
            StartFlight(flight);
            return Task.CompletedTask;
        }
        private void SaveFlightToDb(IFlightLogic flight)
        {
            var log = GenerateFlightEntity(flight);
            _flightRepository.AddFlight(log);
        }
        private FlightLog GenerateFlightEntity(IFlightLogic flight)
        {
            var flightLog = new FlightLog { FlightId = flight.FlightId, FlightName = flight.FlightName, PassangersCount = flight.PassangersCount };
            if (flight.Target == Target.Landing)
                flightLog.LandingTime = DateTime.UtcNow.ToShortDateString();
            else
                flightLog.DepartureTime = DateTime.UtcNow.ToShortDateString();
            return flightLog;
        }
        public async void StartFlight(IFlightLogic flight)
        {
            flights.Add(flight);
            var routeOfFlight = CreateRoute(flight.Target);
            routeOfFlight.Airport = this;
            await flight.Start(routeOfFlight, ActionEvent);
        }
        private IFlightRoute CreateRoute(Target target)
        {
            var stations = legService.GetLegs();
            var path = new FlightRoute();
            if (target == Target.Landing)
                return LoadLandingRoute(stations, path);
            return LoadTakeoffRoute(stations, path);
        }
        public IFlightRoute LoadLandingRoute(IEnumerable<IAirportLeg> legs, IFlightRoute flightRoute)
        {
            var leg1 = legs.FirstOrDefault(s => s.AirportLegId == 1);
            var leg2 = legs.FirstOrDefault(s => s.AirportLegId == 2);
            var leg3 = legs.FirstOrDefault(s => s.AirportLegId == 3);
            var leg4 = legs.FirstOrDefault(s => s.AirportLegId == 4);
            var leg5 = legs.FirstOrDefault(s => s.AirportLegId == 5);
            var leg6 = legs.FirstOrDefault(s => s.AirportLegId == 6);
            flightRoute.Legs.Add(leg1);
            flightRoute.Legs.Add(leg2);
            flightRoute.Legs.Add(leg3);
            flightRoute.Legs.Add(leg4);
            flightRoute.Legs.Add(leg5);
            flightRoute.Legs.Add(leg6);
            return flightRoute;
        }
        public IFlightRoute LoadTakeoffRoute(IEnumerable<IAirportLeg> legs, IFlightRoute flightRoute)
        {
            var leg7 = legs.FirstOrDefault(s => s.AirportLegId == 7);
            var leg8 = legs.FirstOrDefault(s => s.AirportLegId == 8);
            var leg4 = legs.FirstOrDefault(s => s.AirportLegId == 4);
            flightRoute.Legs.Add(leg7);
            flightRoute.Legs.Add(leg8);
            flightRoute.Legs.Add(leg4);
            return flightRoute;
        }
    }
}
