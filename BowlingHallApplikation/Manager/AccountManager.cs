using MatchAPI.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingHallApplikation.Manager
{
    public class AccountManager
    {
        private readonly ApiClient _apiClient;
        public AccountManager(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public string CreateNewAccount(string userName, string password)
        {
            _apiClient.CreateAccount(userName, password);

            return "";
        }

        public string TestAccount()
        {
            _apiClient.TestAccount();

            return "";
        }
    }
}
