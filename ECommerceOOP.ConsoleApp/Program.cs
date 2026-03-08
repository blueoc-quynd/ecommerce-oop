using ECommerceOOP.ECommerceOOP.Domain.Customers;
using ECommerceOOP.ECommerceOOP.Domain.Logging;
using ECommerceOOP.ECommerceOOP.Domain.Orders;
using ECommerceOOP.ECommerceOOP.Domain.Payments;
using ECommerceOOP.ECommerceOOP.Entity;
using ECommerceOOP.ECommerceOOP.Repository;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("╔══════════════════════════════════════╗");
Console.WriteLine("║   E-Commerce OOP - Order System      ║");
Console.WriteLine("╚══════════════════════════════════════╝\n");

// ══════ Khởi tạo infrastructure ══════

// Tạo DbContext với SQLite
var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlite("Data Source=ecommerce.db")
    .Options;

using var dbContext = new AppDbContext(options);
dbContext.Database.EnsureCreated(); // Tự tạo DB + bảng nếu chưa có

// Tạo dependency dùng chung (DIP: phụ thuộc vào interface)
ILogger logger = new ConsoleLogger();
IOrderRepository orderRepository = new OrderRepository(dbContext);

// ═══ Demo 1: Khách thường + Credit Card ═══
Console.WriteLine("═══ Đơn hàng 1: Regular Customer + Credit Card ═══");
IPaymentMethod creditCard = new CreditCardPayment();
var regular = new RegularCustomer("Nguyễn Văn A");
var order1 = new Order(creditCard, logger, orderRepository);
order1.AddItem("Laptop Dell XPS 15", 25_000_000m);
order1.AddItem("Chuột Logitech MX Master", 1_800_000m, 2);
order1.Checkout(regular);
Console.WriteLine();

// ═══ Demo 2: Khách Premium + PayPal ═══
Console.WriteLine("═══ Đơn hàng 2: Premium Customer + PayPal ═══");
IPaymentMethod paypal = new PayPalPayment();
var premium = new PremiumCustomer("Trần Thị B");
var order2 = new Order(paypal, logger, orderRepository);
order2.AddItem("Bàn phím cơ Keychron K2", 2_500_000m);
order2.AddItem("Tai nghe Sony WH-1000XM5", 7_000_000m);
order2.Checkout(premium);
Console.WriteLine();

// ═══ Demo 3: Khách VIP + Tiền mặt ═══
Console.WriteLine("═══ Đơn hàng 3: VIP Customer + Cash ═══");
IPaymentMethod cash = new CashPayment();
var vip = new VipCustomer("Lê Văn C");
var order3 = new Order(cash, logger, orderRepository);
order3.AddItem("Màn hình LG 4K 27\"", 12_000_000m);
order3.AddItem("Webcam Logitech C920", 1_500_000m);
order3.AddItem("Đèn bàn LED Xiaomi", 800_000m, 2);
order3.Checkout(vip);

// ═══ Đọc lại từ DB để chứng minh data đã lưu ═══
Console.WriteLine("\n═══ Tất cả đơn hàng trong DB ═══");
var allOrders = orderRepository.GetAllWithItems();
foreach (var o in allOrders)
{
    Console.WriteLine($"  #{o.Id} | {o.CustomerName} ({o.CustomerType}) | {o.TotalPrice:N0}đ | {o.PaymentMethod} | {o.CreatedAt:HH:mm:ss}");
    foreach (var item in o.Items)
    {
        Console.WriteLine($"       └─ {item.ProductName} x{item.Quantity} - {item.Price:N0}đ");
    }
}

