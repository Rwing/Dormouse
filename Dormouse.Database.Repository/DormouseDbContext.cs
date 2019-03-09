using Dormouse.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dormouse.Database.Repository
{
    public class DormouseDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<VoteItem> VoteItems { get; set; }
        public DbSet<ShareItem> ShareItems { get; set; }

        public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLoggerFactory(MyLoggerFactory).UseNpgsql("Host=192.168.5.197;Database=dormouse;Username=postgres;Password=mysecretpassword");
    }
}
