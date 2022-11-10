using AirportAPI.HubTower;
using Interfaces;
using Models;
using Newtonsoft.Json;

namespace AirportAPI.Services.ControlTower
{
    public class ControlTower
    {
        static IFlightLogic[] flights;
        ControlTowerHub controlTowerHub;
        public static IFlightLogic[] Flights { get => flights; set => flights = value; }
        public static AirportLeg[] Legs { get; set; }
        public ControlTower(ControlTowerHub controlTowerHub)
        {
            this.controlTowerHub = controlTowerHub;
        }
        
        public IEnumerable<IFlightLogic> NotifyClient()
        {
            return flights;
        }
    }
}
