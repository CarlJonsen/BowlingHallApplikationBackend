using BowlingHallApplikation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingHallApplikation.Factory
{
    public static class MatchFactory
    {
        public static Match CreateMatch(string matchval)
        {
            if(matchval == "bowling")
            {
                var match = new BowlingMatch();
                return match;
            }

            if (matchval == "dart")
            {
                var match = new DartMatch(); // Kan alltså nu skapa andra typer av matcher för de ärver från Match
                return match;
            }

            return null;
        }
    }
}
