using DatabaseContext;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        readonly DBContext _dbContext;
        SemaphoreSlim slim = new SemaphoreSlim(1);

        public Action<FlightStationLog> D { get; set; }
        public FlightRepository(DBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public void AddFlight(FlightLog flight)
        {
            _dbContext.Database.OpenConnection();
            try
            {
                _dbContext.FlightLog?.Add(flight);
                _dbContext.SaveChanges();
            }
            finally
            {
                _dbContext.Database.CloseConnection();
            }
        }
        public void CreateEvent(FlightStationLog proccess, FlightLog? flightLog)
        {
            _dbContext.Database.OpenConnection();
            try
            {
                _dbContext.FlightStationLog?.Add(proccess);
                if (flightLog != null)
                    _dbContext.FlightLog?.Add(flightLog!);
                _dbContext.SaveChanges();
            }
            finally
            {
                _dbContext.Database.CloseConnection();
            }
        }
    }
}
