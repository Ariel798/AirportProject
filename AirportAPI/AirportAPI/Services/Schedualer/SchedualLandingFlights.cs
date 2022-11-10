using AirportAPI.Logic;
using AirportAPI.Services.ControlTower;
using Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AirportAPI.Services.Schedualer
{
    public class SchedualLandingFlights
    {
        public bool startedLanding { get; set; }
        readonly ControlTower.ControlTower controlTower;
        readonly ILegsService legsService;
        public static IFlightLogic landingFlight { get; set; }
        public event Func<string> HostingFlightEvent;
        public IFlightLogic[] ArrayOfFlight { get; set; }
        IFlightLogic processFlight;
        object o;
        public SchedualLandingFlights(ILegsService legsService)
        {
            o = new object();
            this.legsService = legsService;
        }
        public AirportStatus GetAirportStatus()
        {
            var status = new AirportStatus();
            status.AirportLegs.AddRange(legsService.GetLegStatus());
            return status;
        }
    }
}
