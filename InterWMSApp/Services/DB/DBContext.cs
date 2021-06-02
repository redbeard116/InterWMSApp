using InterWMSApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InterWMSApp.Services.DB
{
    public class DBContext : DbContext
    {
        #region Fields
        private readonly string _dbConnection = "Host=localhost;PORT=5432;Username=postgres;Password=niyaz;Database=interwms;Integrated Security=true;Pooling=true;";
        #endregion
        public DBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_dbConnection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(w => w.Role).HasConversion<string>();
            modelBuilder.Entity<User>().HasIndex(w => w.Login).IsUnique();
        }

        #region DbSet
        public DbSet<User> Users { get; set; }
        #endregion
    }
}
