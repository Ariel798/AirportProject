
using AirportAPI.Services.Schedualer;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Text.Json;

namespace AirportAPI.HubTower
{
    public class ControlTowerHub : Hub
    {
        SchedualLandingFlights schedualFlights;
        public ControlTowerHub(SchedualLandingFlights schedualFlights)
        {
            this.schedualFlights = schedualFlights;
        }
        public async Task SendStatus()
        {
            var airportStatus = JsonConvert.SerializeObject(schedualFlights.GetAirportStatus());
            await Clients.All.SendAsync("SendStatus", airportStatus);
        }
    }
}
