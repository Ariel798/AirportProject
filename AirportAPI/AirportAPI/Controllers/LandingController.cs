using AirportAPI.Logic;
using AirportAPI.Services;
using AirportAPI.Services.ControlTower;
using AirportAPI.Services.Schedualer;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace AirportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandingController : ControllerBase
    {
        ControlTower controlTower;
        IAirportService flightService;
        SchedualLandingFlights schedualFlights;
        bool _started;
        public LandingController(SchedualLandingFlights schedualFlights, IAirportService flightService)
        {
            this.controlTower = controlTower;
            this.schedualFlights = schedualFlights;
            this.flightService = flightService;
            schedualFlights.HostingFlightEvent += FlightsMoved;
        }
        [HttpPost]
        public ActionResult<string> PostLanding([FromBody] string jsonFlight)
        {
            FlightLogic flight = JsonConvert.DeserializeObject<FlightLogic>(jsonFlight);
            if (flight == null)
            {
                return "";
            }
            flightService.FlightManager(flight);
            var a = schedualFlights.GetAirportStatus();
            return Content(JsonConvert.SerializeObject(a));
        }
        [HttpGet]
        public string FlightsMoved()
        {
            var a = schedualFlights.GetAirportStatus();
            return "Airport is clear...";
        }
        [HttpGet]
        [Route("getstatus")]
        public string GetStatus()
        {
            var airportStatus = JsonConvert.SerializeObject(schedualFlights.GetAirportStatus());
            return airportStatus;
        }
    }
}
