namespace ECommerceOOP.ECommerceOOP.Domain.Payments;

// Thanh toán qua PayPal
public class PayPalPayment : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"  🅿️ [PayPal] Thanh toán thành công: {amount:N0}đ");
    }
}
