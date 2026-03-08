namespace ECommerceOOP.ECommerceOOP.Domain.Customers;

// Khách Premium: discount 10%
public class PremiumCustomer(string name) : Customer(name)
{
    public override decimal GetDiscount() => 0.10m;
}
