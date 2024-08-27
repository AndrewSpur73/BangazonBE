using Microsoft.EntityFrameworkCore;
using BangazonBE.Models;

public class BangazonBEDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<User> Users { get; set; }


    public BangazonBEDbContext(DbContextOptions<BangazonBEDbContext> context) : base(context)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User[]
        {
        new User { Id = 1, Uid = "firebase_key_1", FirstName = "Andyroo", LastName = "Spurlock", UserName = "TalkingLunchbox", Address = "123 Main St", Email = "aspurlock@coding.com", Seller = false },
        new User { Id = 2, Uid = "firebase_key_2", FirstName = "Kathleen", LastName = "Byrd", UserName = "WildthornBerry", Address = "456 Elm St", Email = "scribblekathy@example.com", Seller = true }
        });

        modelBuilder.Entity<Order>().HasData(new Order[]
        {
    new Order { OrderId = 1, Uid = "WWK60quQ2LWs8vr06yi1yKRzEem2", OrderComplete = true, PaymentTypeId = 1 },
    new Order { OrderId = 2, Uid = "WWK60quQ2LWs8vr06yi1yKRzEem2", OrderComplete = false, PaymentTypeId = 2 },
    new Order { OrderId = 3, Uid = "WWK60quQ2LWs8vr06yi1yKRzEem2", OrderComplete = true, PaymentTypeId = 2 }
        });

        modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
        {
        new PaymentType { Id = 1, Category = "Credit Card" },
        new PaymentType { Id = 2, Category = "PayPal" }
        });

        modelBuilder.Entity<ProductType>().HasData(new ProductType[]
        {
        new ProductType { Id = 1, Type = "Accessories" },
        new ProductType { Id = 2, Type = "Tops" },
        new ProductType { Id = 3, Type = "Shoes" },
        new ProductType { Id = 4, Type = "Bottoms" }
        });

        modelBuilder.Entity<Product>().HasData(new Product[]
        {
        new Product { ProductId = 1, Title = "Laptop", ImageUrl = "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RW16TLP?ver=5c8b&q=90&m=6&h=705&w=1253&b=%23FFFFFFFF&f=jpg&o=f&p=140&aim=true", Description = "A nice laptop", ProductTypeId = 1, Price = 999.99M, Quantity = 10, SellerId = 2 },
        new Product { ProductId = 2, Title = "T-shirt", ImageUrl = "https://media.istockphoto.com/id/684650726/photo/blank-t-shirt-color-orange.jpg?s=612x612&w=0&k=20&c=8WUYvzOBuouKdW6t3snwCEnU8mHPiqOjokvbIgZJlXA=", Description = "A nice t-shirt", ProductTypeId = 2, Price = 19.99M, Quantity = 20, SellerId = 2 }
        });


        modelBuilder.Entity<Order>()
             .HasMany(o => o.Products)
             .WithMany(p => p.Orders)
             .UsingEntity(j => j.ToTable("OrderProduct"));

    }
}