using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModule.Models
{
    public class BookingSlot
    {
        public int Id { get; set; }
        public DateTime BookingTime { get; set; }
        public bool IsBooked { get; set; }



        //FK + Navigation props
        public int BowlingLaneId { get; set; }
        public BowlingLane BowlingLane { get; set; }
    }
}
