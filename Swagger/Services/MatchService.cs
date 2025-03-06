using DatabaseModule.Models;
using MatchAPI.ModelsDto;
using MatchAPI.Repository;

namespace MatchAPI.Services
{
    public class MatchService
    {
        private readonly MatchRepo _matchRepo;
        public MatchService(MatchRepo matchRepo)
        {
            _matchRepo = matchRepo;
        }
        public async Task<CreateMatchDto> CreateMatchAsync(string matchName,int accountId,int bookingSlotId,List<string> playerNames)
           {
            if (playerNames == null || playerNames.Count < 2)
            {
                Console.WriteLine("Minst två spelare krävs för att starta en match.");
                return null;
            }

            // Skapa MatchPlayer-objekt med slumpmässiga poäng
            var random = new Random();
            var matchPlayers = playerNames.Select(name => new MatchPlayer
            {
                Name = name,
                Score = random.Next(0, 20) // Slumpmässiga poäng mellan 0 och 20
            }).ToList();

            // Hitta vinnaren baserat på närmast 10 poäng
            var winner = matchPlayers
                .OrderBy(player => Math.Abs(10 - player.Score))
                .ThenByDescending(player => player.Score)
                .First();

            // Skapa matchobjektet
            var newMatch = new Match
            {
                MatchName = matchName,
                WinnerName = winner.Name,
                AccountId = accountId,
                BookingSlotId = bookingSlotId,
                MatchPlayers = matchPlayers
            };


            var match = await _matchRepo.CreateMatchAsync(newMatch);


            CreateMatchDto created = new CreateMatchDto();
            created.WinnerName = match.WinnerName;
            return created;
        }

    }
}
