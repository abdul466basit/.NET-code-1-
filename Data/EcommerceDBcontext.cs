using Microsoft.EntityFrameworkCore;

namespace EFCrud.Data
{
    public class EcommerceDBcontext: DbContext
    {
        public EcommerceDBcontext(DbContextOptions<EcommerceDBcontext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerDetails> CustomersDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-One Relationship
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.CustomerDetails)
                .WithOne(cd => cd.Customer)
                .HasForeignKey<CustomerDetails>(cd => cd.customerId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many Relationship
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.customerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-Many Relationship
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.orderId, op.productId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.orderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.productId)
                .OnDelete(DeleteBehavior.Cascade);


            // Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { customerId = 1, customerName = "Alice Johnson"},
                new Customer { customerId = 2, customerName = "Bob Smith" }
            );

            // Customer Details
            modelBuilder.Entity<CustomerDetails>().HasData(
                new CustomerDetails { customerId = 1, address = "123 Main St", phoneNumber = "123-456-7890" },
                new CustomerDetails { customerId = 2, address = "456 Elm St", phoneNumber = "987-654-3210" }
            );

            // Products
            modelBuilder.Entity<Product>().HasData(
                new Product { productId = 1, productname = "Laptop", price = 1200.00m },
                new Product { productId = 2, productname = "Smartphone", price = 800.00m }
            );

            // Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { orderId = 1, orderDate = new DateTime(2024, 3, 2, 14, 30, 0), customerId = 1 },
                new Order { orderId = 2, orderDate = new DateTime(2024, 3, 2, 12, 00, 0), customerId = 2 }
            );

            // Many-to-Many Relationship (OrderProduct)
            modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct { orderId = 1, productId = 1 },
                new OrderProduct { orderId = 1, productId = 2 },
                new OrderProduct { orderId = 2, productId = 2 }
            );

        }
    }
}
