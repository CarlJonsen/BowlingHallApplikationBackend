using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingHallApplikation.Models
{
    public class BowlingMatch : Match
    {
        public int AccountId { get; set; }
        public int BookingSlotId { get; set; }
        public List<string> PlayerNames { get; set; } = new List<string>();
    }
}
