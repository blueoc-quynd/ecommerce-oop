using ECommerceOOP.ECommerceOOP.Domain.Customers;
using ECommerceOOP.ECommerceOOP.Domain.Logging;
using ECommerceOOP.ECommerceOOP.Domain.Payments;
using ECommerceOOP.ECommerceOOP.Entity;
using ECommerceOOP.ECommerceOOP.Repository;

namespace ECommerceOOP.ECommerceOOP.Domain.Orders;

// Record đại diện cho một sản phẩm trong đơn hàng (Encapsulation: dữ liệu bất biến)
public record OrderItem(string ProductName, decimal Price, int Quantity);

// DIP: Order phụ thuộc vào abstraction (IPaymentMethod, ILogger, IOrderRepository)
// OCP: thêm payment/logger/customer/repository mới mà không cần sửa class này
public class Order
{
    private readonly List<OrderItem> _items = [];
    private readonly IPaymentMethod _paymentMethod;
    private readonly ILogger _logger;
    private readonly IOrderRepository _orderRepository;

    // Constructor Injection: inject tất cả dependency
    public Order(IPaymentMethod paymentMethod, ILogger logger, IOrderRepository orderRepository)
    {
        _paymentMethod = paymentMethod ?? throw new ArgumentNullException(nameof(paymentMethod));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();

    public void AddItem(string productName, decimal price, int quantity = 1)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

        _items.Add(new OrderItem(productName, price, quantity));
        _logger.Log($"Đã thêm: {productName} x{quantity} - {price:N0}đ");
    }

    // Polymorphism: customer.GetDiscount() trả về discount tùy loại khách hàng
    public decimal CalculateTotal(Customer customer)
    {
        var subtotal = _items.Sum(item => item.Price * item.Quantity);
        var discount = customer.GetDiscount();
        return subtotal * (1 - discount);
    }

    public void Checkout(Customer customer)
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Đơn hàng trống, không thể checkout.");

        _logger.Log($"Bắt đầu checkout cho: {customer.Name}");

        var subtotal = _items.Sum(item => item.Price * item.Quantity);
        var total = CalculateTotal(customer);

        _logger.Log($"Tạm tính: {subtotal:N0}đ");
        _logger.Log($"Discount ({customer.GetType().Name}): {customer.GetDiscount():P0}");
        _logger.Log($"Thành tiền: {total:N0}đ");

        // Polymorphism: gọi Pay() không cần biết loại payment cụ thể
        _paymentMethod.Pay(total);

        // Chuyển Domain → Entity rồi lưu DB thông qua Repository
        var entity = ToEntity(customer, subtotal, total);
        _orderRepository.Save(entity);
        _logger.Log($"Đã lưu đơn hàng vào DB (Id: {entity.Id})");

        _logger.Log("Checkout hoàn tất!");
    }

    // Chuyển đổi Domain Model → Entity (data để lưu DB)
    private OrderEntity ToEntity(Customer customer, decimal subtotal, decimal total)
    {
        return new OrderEntity
        {
            CustomerName = customer.Name,
            CustomerType = customer.GetType().Name,
            Subtotal = subtotal,
            Discount = customer.GetDiscount(),
            TotalPrice = total,
            PaymentMethod = _paymentMethod.GetType().Name,
            CreatedAt = DateTime.Now,
            Items = _items.Select(item => new OrderItemEntity
            {
                ProductName = item.ProductName,
                Price = item.Price,
                Quantity = item.Quantity
            }).ToList()
        };
    }
}
