namespace ECommerceOOP.ECommerceOOP.Entity;

// Entity map với bảng OrderItems trong DB
public class OrderItemEntity
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    // Foreign key đến OrderEntity
    public int OrderId { get; set; }
    public OrderEntity Order { get; set; } = null!;
}
