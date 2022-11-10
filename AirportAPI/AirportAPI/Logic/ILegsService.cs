using Interfaces;
using Models;

namespace AirportAPI.Logic
{
    public interface ILegsService
    {
        public IEnumerable<IAirportLeg> GetLegs();
        public IEnumerable<IAirportLeg> GetLegStatus();
    }
}