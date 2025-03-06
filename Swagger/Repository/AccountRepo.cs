using DatabaseModule.Models;
using MatchAPI.ModelsDto;
using Microsoft.EntityFrameworkCore;

namespace MatchAPI.Repository
{
    public class AccountRepo 
    {
        private readonly BowlingDbContext dbContext;

        public AccountRepo(BowlingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Account GetAccountByUsername(string userName)
        {
            return dbContext.Accounts.FirstOrDefault(a => a.Name == userName);
        }

        public Account CreateAccount(Account account)
        {
            var newAccount = dbContext.Accounts.Add(account).Entity;
            dbContext.SaveChanges();
            return newAccount;
        }

        public List<Match> GetMatchesByAccountId(int accountId)
        {
            return dbContext.Matches
                .Where(m => m.AccountId == accountId)
                .Include(m => m.BookingSlot)
                .ThenInclude(bs => bs.BowlingLane)
                .Include(m => m.MatchPlayers)
                .ToList();
        }


    }
}
