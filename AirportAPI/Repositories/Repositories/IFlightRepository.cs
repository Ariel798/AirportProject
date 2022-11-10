using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public interface IFlightRepository
    {
        public Action<FlightStationLog> D { get; set; }
    }
}
