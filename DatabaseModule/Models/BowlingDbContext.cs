using Microsoft.EntityFrameworkCore;

using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DatabaseModule.Models
{
    public class BowlingDbContext : DbContext
    {
        public BowlingDbContext(DbContextOptions<BowlingDbContext> options) : base(options) { }


        public DbSet<Account> Accounts { get; set; }
        public DbSet<BookingSlot> BookingSlots { get; set; }
        public DbSet<BowlingLane> BowlingLanes { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchPlayer> MatchPlayers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CARLLAPTOP\\MSSQLSERVER01;Database=BowlingDb;Trusted_Connection=True;TrustServerCertificate=True");

            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Server=CARLLAPTOP\\MSSQLSERVER01;Database=BowlingDb;Trusted_Connection=True;TrustServerCertificate=True");

            //   // throw new Exception("Databasen verkar inte ha någon connection sträng");
            //}
        }
    }
}
