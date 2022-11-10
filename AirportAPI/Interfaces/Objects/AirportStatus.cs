
namespace Interfaces
{
    public class AirportStatus
    {
        public List<IAirportLeg> AirportLegs { get; set; }
        public AirportStatus()
        {
            AirportLegs = new List<IAirportLeg>();
        }
    }
}
