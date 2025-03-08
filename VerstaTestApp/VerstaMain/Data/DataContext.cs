using Microsoft.EntityFrameworkCore;
using VerstaMain.Data.Models;

namespace VerstaMain.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);
        }
    }
}
