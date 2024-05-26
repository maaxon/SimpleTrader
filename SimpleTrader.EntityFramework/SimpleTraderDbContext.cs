using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssetTransaction> AssetTransactions { get; set; }
        public DbSet<AssetQueue> AssetsQueue { get; set; }
        public DbSet<StockDescription> StockDescriptions { get; set; }
        public SimpleTraderDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Asset);

            base.OnModelCreating(modelBuilder);
        }
    }
}

