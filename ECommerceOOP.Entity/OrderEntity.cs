namespace ECommerceOOP.ECommerceOOP.Entity;

// Entity map với bảng Orders trong DB — chỉ chứa data, không có logic nghiệp vụ
public class OrderEntity
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerType { get; set; } = string.Empty;
    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation property: 1 Order có nhiều OrderItem
    public List<OrderItemEntity> Items { get; set; } = [];
}
