using DatabaseModule.Models;
using MatchAPI.ModelsDto;
using MatchAPI.Repository;

namespace MatchAPI.Services
{
    public class AccountService
    {
        private readonly AccountRepo _accountRepo;

        public AccountService(AccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public AccountDto CreateNewAccount(string userName, string password)
        {
            var existingAccount = _accountRepo.GetAccountByUsername(userName);

            if (existingAccount != null)
            {
                throw new Exception("Användarnamnet är redan upptaget.");
            }

            var newAccount = new Account
            {
                Name = userName,
                Password = password
            };

            var finalAccount = _accountRepo.CreateAccount(newAccount);

            return new AccountDto { Username = finalAccount.Name, Id = finalAccount.Id};
        }

        public AccountDto LogInAccount(string userName, string password)
        {
            var account = _accountRepo.GetAccountByUsername(userName);

            if (account == null || account.Password != password)
            {
                throw new Exception("Felaktigt användarnamn eller lösenord.");
            }

            return new AccountDto { Username = account.Name, Id = account.Id};
        }

        public List<MatchHistoryDto> GetMatchHistoryByAccountId(int accountId)
        {
            var matches = _accountRepo.GetMatchesByAccountId(accountId);

            return matches.Select(m => new MatchHistoryDto
            {
                MatchName = m.MatchName,
                WinnerName = m.WinnerName,
                BookingTime = m.BookingSlot.BookingTime,
                LaneName = m.BookingSlot.BowlingLane.LaneName,
                PlayerNames = m.MatchPlayers.Select(p => p.Name).ToList()
            }).ToList();
        }

    }
}
