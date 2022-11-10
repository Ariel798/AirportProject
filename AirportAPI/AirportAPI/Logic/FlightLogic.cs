using AirportAPI.Logic.FlightRoute;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace AirportAPI.Logic
{
    public class FlightLogic : IFlightLogic
    {
        public FlightLogic()
        {

        }
        public int FlightId { get; set; }
        [ForeignKey("FlightName")]
        public string? FlightName { get; set; }
        public int PassangersCount { get; set; }
        public Target Target { get; set; }
        public IAirportLeg AirportLeg { get; set; }
        public bool CompletedProcess { get; set; }

        public Task Start(IFlightRoute flightRoute, Action<FlightStationLog,IFlightLogic> action)
        {
            return Task.Run(() => MoveFlight(flightRoute, action));
        }
        private async Task MoveFlight(IFlightRoute flightRoute, Action<FlightStationLog,IFlightLogic> action)
        {
            int counterOfStation = 0;
            foreach (var iStation in flightRoute.GetNextStation())
            {
                counterOfStation++;
                IAirportLeg airportLeg;
                airportLeg = (AirportLeg)iStation;
                var process = new FlightStationLog {PlaneId = this.FlightId, LegId = iStation.AirportLegId, CreationTime = DateTime.Now };
                if (action != null)
                    action.Invoke(process,this);
                if(flightRoute.Legs.Count == counterOfStation)
                {
                    CompletedProcess = true;
                    process.Id = 0;
                    action.Invoke(process, this);
                }
                await StationMovement(airportLeg);
            }
            string landingOrTakeoff = (int)Target == 1 ? "takeoff" : "landing";
            Console.WriteLine("Flight: " + this.FlightName + " has completed its " + landingOrTakeoff);
        }

        private async Task StationMovement(IAirportLeg airportLeg)
        {
            await Task.Run(() => airportLeg.Enter(this));
            await Task.Run(() => airportLeg.ExitStation(this));
        }
    }
}
