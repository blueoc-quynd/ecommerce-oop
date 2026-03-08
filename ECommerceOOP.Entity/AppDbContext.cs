using Microsoft.EntityFrameworkCore;

namespace ECommerceOOP.ECommerceOOP.Entity;

// DbContext: cầu nối giữa code C# và database
// Mỗi DbSet<T> tương ứng với 1 bảng trong DB
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<OrderEntity> Orders => Set<OrderEntity>();
    public DbSet<OrderItemEntity> OrderItems => Set<OrderItemEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Cấu hình quan hệ 1-N: Order có nhiều Items
        modelBuilder.Entity<OrderEntity>(entity =>
        {
            entity.HasKey(o => o.Id);
            entity.Property(o => o.TotalPrice).HasPrecision(18, 2);
            entity.Property(o => o.Subtotal).HasPrecision(18, 2);
            entity.Property(o => o.Discount).HasPrecision(5, 2);
        });

        modelBuilder.Entity<OrderItemEntity>(entity =>
        {
            entity.HasKey(i => i.Id);
            entity.Property(i => i.Price).HasPrecision(18, 2);
            entity.HasOne(i => i.Order)
                  .WithMany(o => o.Items)
                  .HasForeignKey(i => i.OrderId);
        });
    }
}
