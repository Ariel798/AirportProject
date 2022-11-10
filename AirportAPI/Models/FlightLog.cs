using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FlightLog
    {
        [Required]
        [Key]
        public int FlightId { get; set; }
        public string? FlightName { get; set; }
        public string? LandingTime { get; set; }
        public string? DepartureTime { get; set; }
        public int PassangersCount { get; set; }
    }
}
