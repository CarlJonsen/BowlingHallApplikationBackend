using DatabaseModule.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModule
{
    public class BowlingDbContext : DbContext
    {
        public BowlingDbContext(DbContextOptions<BowlingDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<BookingSlot> BookingSlots { get; set; }
        public DbSet<BowlingLane> BowlingLanes { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchPlayer> MatchPlayers { get; set; }
    }
}
