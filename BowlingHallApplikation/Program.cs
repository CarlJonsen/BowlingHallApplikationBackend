using BowlingHallApplikation.Manager;
using MatchAPI.ModelsDto;
using System.Security.Principal;

namespace BowlingHallApplikation
{
    internal class Program
    {

        static void Main()
        {
            RunAsync().Wait();

        }

        static async Task RunAsync()
        {

            var apiClient = new ApiClient("https://localhost:7134");
            AccountManager accountManager = new AccountManager(apiClient);



            Console.WriteLine("Användarnamn: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Lösenord´: ");
            string password = Console.ReadLine();

            accountManager.CreateNewAccount(userName, password);

            //accountManager.TestAccount(); 

            //using (var client = new HttpClient())
            //{
            //    var result = await client.GetAsync("https://localhost:7134/Account/Account");
            //    var response = await result.Content.ReadAsStringAsync();
            //}
        }
    }
}
