using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AirportLeg : IAirportLeg
    {
        public int AirportLegId { get; set; }
        public IFlightLogic Flight { get; set; }
        public Action<IAirportLeg>? Free { get; set; }
        public AirportLeg NextLeg { get; set; }
        public Task Enter(IFlightLogic flight)
        {
            if (Flight == null)
            {
                Flight = flight;
                lock (Flight)
                {
                    Console.WriteLine(this.Flight.FlightName + " in " + this.AirportLegId);
                    Thread.Sleep(2000);
                }
            }
            return Task.CompletedTask;
        }
        public Task ExitStation(IFlightLogic flight)
        {
            lock (Flight)
            {
                if (Flight != null)
                {
                    Console.WriteLine(this.Flight.FlightName + " out " + this.AirportLegId);
                    Thread.Sleep(2000);
                    Flight = null;
                }
            }
            Free?.Invoke(NextLeg);
            return Task.CompletedTask;
        }
    }
}
