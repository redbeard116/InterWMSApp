using InterWMSApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InterWMSApp.Services.DB
{
    public class DBContext : DbContext
    {
        #region Fields
        private readonly string _dbConnection = "Host=localhost;PORT=5432;Username=postgres;Password=1;Database=interwms;Integrated Security=true;Pooling=true;";
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
            modelBuilder.Entity<Operation>().Property(w => w.Type).HasConversion<string>();
            modelBuilder.Entity<RightsGrid>().Property(w => w.UserRole).HasConversion<string>();

            modelBuilder.Entity<Auth>().HasIndex(w => w.Login).IsUnique();
            modelBuilder.Entity<RightsGrid>().HasIndex(w => w.UserRole).IsUnique();

            modelBuilder.Entity<Auth>().HasOne(w => w.User).WithMany(w => w.Auths).HasForeignKey(w => w.UserId);
            modelBuilder.Entity<Product>().HasOne(p => p.ProductType).WithMany(t => t.Products).HasForeignKey(p => p.TypeId);
            modelBuilder.Entity<Contract>().HasOne(w => w.Counterparty).WithMany(w => w.Contracts).HasForeignKey(w => w.CounterpartyId);
            modelBuilder.Entity<Counterparty>().HasOne(w => w.User).WithMany(w => w.Counterparties).HasForeignKey(w => w.UserId);
            modelBuilder.Entity<Operation>().HasOne(w => w.Product).WithMany(w => w.Operations).HasForeignKey(w => w.ProductId);
            modelBuilder.Entity<ProductStorage>().HasOne(w => w.Product).WithMany(w => w.ProductStorages).HasForeignKey(w => w.ProductId);
            modelBuilder.Entity<ProductStorage>().HasOne(w => w.StorageArea).WithMany(w => w.ProductStorages).HasForeignKey(w => w.StorageAreaId);
            modelBuilder.Entity<RightsGrid>().HasOne(w => w.AccessType).WithMany(w => w.RightsGrids).HasForeignKey(w => w.AccessTypeId);
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
        public DbSet<ProductStorage> ProductStorages { get; set; }
        public DbSet<StorageArea> StorageAreas { get; set; }
        #endregion
    }
}
