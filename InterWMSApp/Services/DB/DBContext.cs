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
            modelBuilder.Entity<RightsGrid>().HasNoKey();

            modelBuilder.Entity<User>().Property(w => w.Role).HasConversion<string>();
            modelBuilder.Entity<Operation>().Property(w => w.Type).HasConversion<string>();
            modelBuilder.Entity<RightsGrid>().Property(w => w.UserRole).HasConversion<string>();

            modelBuilder.Entity<Auth>().HasIndex(w => w.Login).IsUnique();
            modelBuilder.Entity<RightsGrid>().HasIndex(w => w.UserRole).IsUnique();
        }

        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Auth> Auths { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<AccessType> AccessTypes { get; set; }
        public DbSet<Counterparty> Counterparties { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<RightsGrid> RightsGrids{ get; set; }
        #endregion
    }
}
