using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LegEntity
    {
        [Key]
        public int LegNumber { get; set; }
        public string LegTarget { get; set; }
    }
}
