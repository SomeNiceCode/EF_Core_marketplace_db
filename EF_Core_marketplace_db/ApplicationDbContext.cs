using Microsoft.EntityFrameworkCore;
using EF_Core_marketplace_db.Models;

namespace EF_Core_marketplace_db
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SellerOrder> SellerOrders { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = MarketPlaceFirstVersion; Trusted_Connection = True; TrustServerCertificate = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ProductOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId }); // тут говорим что у нас есть 2 первичных ключа для 

            modelBuilder.Entity<ProductOrder>()
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductOrder)
                .HasForeignKey(po => po.ProductId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(o => o.Order)
                .WithMany(o => o.ProductOrder)
                .HasForeignKey(po => po.OrderId);



            modelBuilder.Entity<SellerOrder>()
                .HasKey(so => new { so.SellerId, so.OrderId }); // тут говорим что у нас есть 2 первичных ключа для заказа и продавца

            modelBuilder.Entity<SellerOrder>()
                .HasOne(s => s.Seller)
                .WithMany(s => s.SellerOrder)
                .HasForeignKey(so => so.SellerId);

            modelBuilder.Entity<SellerOrder>()
                .HasOne(o => o.Order)
                .WithMany(o => o.SellerOrder)
                .HasForeignKey(po => po.OrderId);
        }
    }
}
