using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class FlightStationLog
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("FlightId")]
        public int PlaneId { get; set; }
        [ForeignKey("LegId")]
        public int LegId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
