using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.HasData(
                new Product(){ProductId = 1, CategoryId = 2,ImageUrl = "/images/desktop.jpg", ProductName = "Computer", Price = 17_000},
                new Product(){ProductId = 2, CategoryId = 2,ImageUrl = "/images/keyboard.jpg", ProductName = "Keyboard", Price = 1_000},
                new Product(){ProductId = 3, CategoryId = 2,ImageUrl = "/images/mouse.jpg", ProductName = "Mouse", Price = 500},
                new Product(){ProductId = 4, CategoryId = 2,ImageUrl = "/images/monitor.jpg", ProductName = "Monitor", Price = 7_000},
                new Product(){ProductId = 5, CategoryId = 2,ImageUrl = "/images/headset.jpg", ProductName = "Headset", Price = 1_500},
                new Product(){ProductId = 6, CategoryId = 1,ImageUrl = "/images/history.jpg", ProductName = "History", Price = 50},
                new Product(){ProductId = 7, CategoryId = 1,ImageUrl = "/images/hamlet.jpg", ProductName = "Hamlet", Price = 80}
            );
        }
    }
}