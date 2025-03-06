using DatabaseModule.Models;

namespace MatchAPI.Repository
{
    public class MatchRepo
    {
        private readonly BowlingDbContext dbContext;
        public MatchRepo(BowlingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Match> CreateMatchAsync(Match match)
        {
            await dbContext.Matches.AddAsync(match);
            await dbContext.SaveChangesAsync();
            return match;
        }
    }
}
