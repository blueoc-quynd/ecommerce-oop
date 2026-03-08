namespace ECommerceOOP.ECommerceOOP.Domain.Payments;

// Abstraction: định nghĩa hành vi thanh toán, không quan tâm chi tiết bên trong
public interface IPaymentMethod
{
    void Pay(decimal amount);
}
