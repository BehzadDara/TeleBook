using Microsoft.EntityFrameworkCore;
using TeleBook.Domain.Models;
using TeleBook.Infrastructure.Implementations;

namespace TeleBook.Infrastructure
{
    public class TeleBookDbContext : DbContextBase
    {
        public DbSet<Tele> Tells { get; set; }
        
        public TeleBookDbContext(DbContextOptions options) :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tele>().HasKey(x => x.Id);
        }
    }
}