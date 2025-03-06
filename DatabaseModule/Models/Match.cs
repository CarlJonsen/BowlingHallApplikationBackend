using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModule.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string MatchName { get; set; } // T.ex CarlOpen2025
        public string WinnerName { get; set; }


        //FK + Navigation props
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int BookingSlotId {  get; set; }
        public BookingSlot BookingSlot { get; set; }

        // Many-to-Many-Relation to MatchPlayer
        public ICollection<MatchPlayer> MatchPlayers { get; set; } = new List<MatchPlayer>();
    }
}
