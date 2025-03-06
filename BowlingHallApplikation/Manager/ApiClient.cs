using MatchAPI.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BowlingHallApplikation.Manager
{
    public class ApiClient
    {   
        private readonly HttpClient _httpClient;

        public ApiClient(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<string> CreateAccount(string userName, string password)
        {
            var newAccount = new AccountDto();
            newAccount.Username = userName;
            newAccount.Password = password;

            //r response = await _httpClient.PostAsJsonAsync("/Account/create", newAccount);
            //var test = await _httpClient.GetAsync("https://localhost:7134/Account/Account");

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("https://localhost:7134/Account/Account");
                var response = await result.Content.ReadAsStringAsync();
            }

            return ":";
        }

        public async Task<string> TestAccount()
        {
            try
            {
                var response = await _httpClient.GetAsync("/Account/Account");
                return "response";
            }
            catch (Exception ex)
            {
                var t = ex;
                return t.Message;
            }
            
        }
    }
}
