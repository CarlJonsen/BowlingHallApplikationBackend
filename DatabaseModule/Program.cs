using System.IO; // För Directory.GetCurrentDirectory()
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DatabaseModule.Models;

internal class Program
{
    static void Main(string[] args)
    {
    //    var services = new ServiceCollection();

    //    // Ladda konfiguration från appsettings.json
    //    var configuration = new ConfigurationBuilder()
    //        .SetBasePath(Directory.GetCurrentDirectory()) // 💡 Borde nu fungera korrekt
    //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    //        .Build();

    //    // Registrera BowlingDbContext med connection string från appsettings.json
    //    services.AddDbContext<BowlingDbContext>(options =>
    //        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    //    var serviceProvider = services.BuildServiceProvider();

    //    using (var context = serviceProvider.GetRequiredService<BowlingDbContext>())
    //    {
    //       context.Database.Migrate();
    //    }
    }
}