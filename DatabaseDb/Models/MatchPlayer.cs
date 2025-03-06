using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModule.Models
{
    public class MatchPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}
