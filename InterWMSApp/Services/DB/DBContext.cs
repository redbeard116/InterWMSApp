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
            modelBuilder.Entity<Contract>().Property(w => w.Type).HasConversion<string>();
            modelBuilder.Entity<RightsGrid>().Property(w => w.UserRole).HasConversion<string>();
            modelBuilder.Entity<ProductPrice>().Property(w => w.PriceType).HasConversion<string>();

            modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<OperationProduct>().HasKey(w => new { w.ContractId, w.ProductId });


            modelBuilder.Entity<Auth>().HasIndex(w => w.Login).IsUnique();
            modelBuilder.Entity<RightsGrid>().HasIndex(w => w.UserRole).IsUnique();

            modelBuilder.Entity<Auth>().HasOne(w => w.User).WithOne(w => w.Auth);
            modelBuilder.Entity<Product>().HasOne(p => p.ProductType).WithMany(t => t.Products).HasForeignKey(p => p.TypeId);
            modelBuilder.Entity<Contract>().HasOne(w => w.Counterparty).WithMany(w => w.Contracts).HasForeignKey(w => w.CounterpartyId);
            modelBuilder.Entity<Counterparty>().HasOne(w => w.User).WithOne(w => w.Counterparty);
            modelBuilder.Entity<Product>().HasOne(w => w.StorageArea).WithMany(w => w.Products).HasForeignKey(w=>w.StorageAreaId);
            modelBuilder.Entity<RightsGrid>().HasOne(w => w.AccessType).WithMany(w => w.RightsGrids).HasForeignKey(w => w.AccessTypeId);
            modelBuilder.Entity<ProductPrice>().HasOne(w => w.Product).WithMany(w => w.ProductPrices).HasForeignKey(w => w.ProductId);
            modelBuilder.Entity<OperationProduct>().HasOne(w => w.Contract).WithMany(w => w.OperationProducts).HasForeignKey(w => w.ContractId);
            modelBuilder.Entity<OperationProduct>().HasOne(w => w.Product).WithMany(w => w.OperationProducts).HasForeignKey(w => w.ProductId);
            modelBuilder.Entity<NumberProducts>().HasOne(w => w.Product).WithOne(w => w.NumberProduct);
        }

        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Auth> Auths { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<AccessType> AccessTypes { get; set; }
        public DbSet<Counterparty> Counterparties { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<RightsGrid> RightsGrids { get; set; }
        public DbSet<StorageArea> StorageAreas { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<OperationProduct> OperationProducts { get; set; }
        public DbSet<NumberProducts> NumberProducts { get; set; }
        #endregion
    }
}
