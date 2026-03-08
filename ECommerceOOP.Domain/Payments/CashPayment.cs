namespace ECommerceOOP.ECommerceOOP.Domain.Payments;

// Thanh toán bằng tiền mặt
public class CashPayment : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"  💵 [Cash] Thanh toán thành công: {amount:N0}đ");
    }
}
