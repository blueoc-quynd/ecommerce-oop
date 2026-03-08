namespace ECommerceOOP.ECommerceOOP.Domain.Payments;

// Thanh toán bằng thẻ tín dụng
public class CreditCardPayment : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"  💳 [Credit Card] Thanh toán thành công: {amount:N0}đ");
    }
}
